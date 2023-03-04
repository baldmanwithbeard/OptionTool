using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="ValueEnumGroup"/>.
    /// </summary>
    public class ValueEnumGroupRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => TableNames.OptionEnumGroup;

        /// <remarks>Overridden to populate <seealso cref="ValueEnumGroup.EnumItems"/> off of a linking table.</remarks>
        /// <inheritdoc />
        protected override T DataRowMapToObject<T>(DataRow dataRow)
        {
            var objectInstance = Activator.CreateInstance<T>();

            objectInstance.GetType().GetProperty("Id")!.SetValue(objectInstance, dataRow["Id"]);
            objectInstance.GetType().GetProperty("EnumItems")!.SetValue(objectInstance, GetEnumItemsByEnumGroupId((int)dataRow["Id"]));

            return objectInstance;
        }

        /// <remarks>
        ///     Overridden to skip non-table property <seealso cref="ValueEnumGroup.EnumItems"/>.<br/>
        ///     Does not handle cascade inserts to other tables.
        /// </remarks>
        /// <inheritdoc />
        protected override string Insert<T>(T insertObject)
        {
            throw new NotImplementedException();
        }

        //TODO: write cascade insert method

        /// <summary>
        ///     Uses linking table to retrieve <seealso cref="ValueEnumGroup.EnumItems"/>.
        /// </summary>
        /// <param name="groupId"></param>
        private static List<ValueEnumItem> GetEnumItemsByEnumGroupId(int groupId)
        {
            var dataTable = DatabaseConnection.GetDataTableFromQuery($"SELECT * FROM {TableNames.OptionEnumItemGroup} WHERE GroupId = {groupId}");

            return (from DataRow dataRow in dataTable.Rows select new ValueEnumItemRepository().GetById((int)dataRow["ItemId"])).ToList();
        }

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="ValueEnumGroup"/>.</remarks>
        // ReSharper disable once UnusedMember.Global
        public IEnumerable<ValueEnumGroup> GetAll() => GetAll<ValueEnumGroup>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="ValueEnumGroup"/>.</remarks>
        public ValueEnumGroup GetById(int id) => GetById<ValueEnumGroup>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="ValueEnumGroup"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(ValueEnumGroup insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="ValueEnumGroup"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(ValueEnumGroup deleteObject) => Delete(deleteObject.Id);
    }
}