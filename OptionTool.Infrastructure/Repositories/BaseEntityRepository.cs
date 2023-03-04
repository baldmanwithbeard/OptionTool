using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OptionTool.Domain;

namespace OptionTool.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="BaseEntity"/>.
    /// </summary>
    /// <remarks>
    ///     Must be inherited by repositories of objects that inherit <seealso cref="BaseEntity"/>
    /// </remarks>
    public abstract class BaseEntityRepository
    {
        /// <summary> Name of object's corresponding table in database. </summary>
        protected abstract string TableName { get; }

        /// <summary>
        ///     Creates instance of specified object <typeparamref name="T"/> from provided DataRow.<br/>
        ///     Defines mappings between table columns and object properties.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <returns>instance of object</returns>
        /// <remarks>
        ///     Will break if corresponding table's columns do not match object <typeparamref name="T"/>'s properties; must override this method<br/>
        ///     in complex objects, like ones with other objects as properties / needing foreign key mappings.<br/>
        ///     (see <seealso cref="OptionInformationRepository.DataRowMapToObject{T}"/> for example of override)
        /// </remarks>
        protected virtual T DataRowMapToObject<T>(DataRow dataRow)
        {
            var objectInstance = Activator.CreateInstance<T>();
            foreach (var prop in objectInstance.GetType().GetProperties())
            {
                if (!Equals(dataRow[prop.Name], DBNull.Value))
                {
                    prop.SetValue(objectInstance, dataRow[prop.Name], null);
                }
            }

            return objectInstance;
        }

        /// <summary>
        ///     Uses reflection to build the insert command for an object's corresponding SQL table.
        /// </summary>
        /// <typeparam name="T">Object Type, child of BaseEntity</typeparam>
        /// <param name="insertObject">object instance</param>
        /// <returns>SQL insert statement</returns>
        /// <remarks>
        ///     HACK: This method assumes that every non-Id property is a string (or other type that SQL uses single quotes for).
        ///     <br/>If using this project as a template/guide, note that you may have to rewrite this method.
        /// </remarks>
        protected virtual string InsertCommandBuilder<T>(T insertObject) where T : BaseEntity
        {
            var insertCommand = new StringBuilder($"INSERT INTO {TableName} values(");

            var properties = Activator.CreateInstance<T>().GetType().GetProperties().ToList();

            // Since Id is inherited from base entity, it is always the last element in the collection returned by GetProperties(), so here
            // it is taken from the end, added to the insertCommand, and removed from the list, so that all values are in column order.
            insertCommand.Append($"{properties.Last().GetValue(insertObject)},");
            properties.RemoveAt(properties.Count - 1);

            foreach (var stringProperty in properties)
            {
                //HACK: this line assumes every property is a string, since it inserts the single quote before and after
                insertCommand.Append($"'{stringProperty.GetValue(insertObject)}',");
            }
            insertCommand.Remove(insertCommand.Length - 1, 1).Append(")");

            return insertCommand.ToString();
        }

        /// <summary>
        ///     Gets all records from database for specified object <typeparamref name="T"/> as enumerable of the object.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        protected IEnumerable<T> GetAll<T>() => (from DataRow dataRow in GetDataTable().Rows select DataRowMapToObject<T>(dataRow)).ToList();

        /// <summary>
        ///     Retrieves instance of specified object <typeparamref name="T"/> with properties populated from DataRow corresponding to provided Id, loaded from database.
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="T">object type</typeparam>
        protected T GetById<T>(int id) => DataRowMapToObject<T>(GetDataRow(id));

        /// <summary>
        ///     Writes a new record to object <typeparamref name="T"/>'s corresponding table in database.
        /// </summary>
        /// <param name="insertObject">instance of object that needs to be written to database</param>
        /// <typeparam name="T">object type, must have parent <seealso cref="BaseEntity"/></typeparam>
        /// <returns> result message </returns>
        /// <remarks>
        ///     Not exposed; must be wrapped/called in inheriting repository classes to ensure it is never passed an object type <typeparamref name="T"/><br/>
        ///     that does not correspond to current repository instance's <seealso cref="TableName"/><br/>
        ///     (see <seealso cref="OptionTreeRepository.Insert"/> for example of how to wrap/call)<br/><br/>
        ///
        ///     Will break if corresponding table's columns do not match object <typeparamref name="T"/>'s properties; must override this method<br/>
        ///     in complex objects, like ones with other objects as properties / needing foreign key mappings.<br/>
        ///     (see <seealso cref="OptionInformationRepository.Insert{T}"/> for example of override)
        /// </remarks>
        //TODO: may be better to move the error handling elsewhere and not return a string here
        protected virtual string Insert<T>(T insertObject) where T : BaseEntity
        {
            try
            {
                return DatabaseConnection.UpdateDataTableFromQuery(InsertCommandBuilder(insertObject)) == 1 ? "Created 1 record successfully" : "Failed without exception";
            }
            catch (Exception e)
            {
                return $"Failed with message {e.Message}";
            }
        }

        /// <summary>
        ///     Deletes record with specified <paramref name="id"/> from table specified in current instance's <seealso cref="TableName"/> property.
        /// </summary>
        /// <returns> result message </returns>
        /// <remarks>
        ///     Not exposed; enforcing wrapping/calling in inheriting repository classes to ensure safe usage.<br/>
        ///     (see <seealso cref="OptionTreeRepository.Delete"/> for example of how to wrap/call)<br/><br/>
        /// </remarks>
        //TODO: may be better to move the error handling elsewhere and not return a string here
        protected string Delete(int id)
        {
            try
            {
                return DatabaseConnection.UpdateDataTableFromQuery($"DELETE FROM {TableName} WHERE Id = {id}") == 1 ? "Deleted 1 record successfully" : "Failed without exception";
            }
            catch (Exception e)
            {
                return $"Failed with message {e.Message}";
            }
        }

        /// <summary>
        ///     Gets full table of data from database, from table specified in current instance's <seealso cref="TableName"/> property.
        /// </summary>
        private DataTable GetDataTable() => DatabaseConnection.GetDataTableFromQuery($"SELECT * FROM {TableName}");

        /// <summary>
        ///     Gets a specific row of data from database, from table specified in current instance's <seealso cref="TableName"/> property.
        /// </summary>
        private DataRow GetDataRow(int id) => DatabaseConnection.GetDataTableFromQuery($"SELECT * FROM {TableName} WHERE Id = {id}").Rows[0];
    }
}