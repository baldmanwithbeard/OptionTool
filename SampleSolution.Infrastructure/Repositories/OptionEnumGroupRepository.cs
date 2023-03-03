using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionEnumGroup"/>.
    /// </summary>
    public class OptionEnumGroupRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => "OptionEnumGroups";

        /// <remarks>Overridden to populate <seealso cref="OptionEnumGroup.EnumItems"/> off of a linking table.</remarks>
        /// <inheritdoc />
        protected override T DataRowMapToObject<T>(DataRow dataRow)
        {
            var objectInstance = Activator.CreateInstance<T>();

            objectInstance.GetType().GetProperty("Id")!.SetValue(objectInstance, dataRow["Id"]);
            objectInstance.GetType().GetProperty("EnumItems")!.SetValue(objectInstance, GetEnumItemsByEnumGroupId((int)dataRow["Id"]));

            return objectInstance;
        }

        /// <remarks>
        ///     Overridden to skip non-table property <seealso cref="OptionEnumGroup.EnumItems"/>.<br/>
        ///     Does not handle cascade inserts to other tables.
        /// </remarks>
        /// <inheritdoc />
        protected override string Insert<T>(T insertObject)
        {
            throw new NotImplementedException();
        }

        //TODO: write cascade insert method

        /// <summary>
        ///     Uses linking table to retrieve <seealso cref="OptionEnumGroup.EnumItems"/>.
        /// </summary>
        /// <param name="groupId"></param>
        private static List<OptionEnumItem> GetEnumItemsByEnumGroupId(int groupId)
        {
            var dataTable = DatabaseConnection.GetDataTableFromQuery($"SELECT * FROM OptionEnumItemGroups WHERE EnumGroupId = {groupId}");

            return (from DataRow dataRow in dataTable.Rows select new OptionEnumItemRepository().GetById((int)dataRow["EnumItemId"])).ToList();
        }

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionEnumGroup"/>.</remarks>
        // ReSharper disable once UnusedMember.Global
        public IEnumerable<OptionEnumGroup> GetAll() => GetAll<OptionEnumGroup>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionEnumGroup"/>.</remarks>
        public OptionEnumGroup GetById(int id) => GetById<OptionEnumGroup>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionEnumGroup"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionEnumGroup insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionEnumGroup"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionEnumGroup deleteObject) => Delete(deleteObject.Id);
    }
}