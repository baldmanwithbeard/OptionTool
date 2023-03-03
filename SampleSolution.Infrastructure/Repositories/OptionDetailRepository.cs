using System;
using System.Collections.Generic;
using System.Data;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionDetail"/>.
    /// </summary>
    public class OptionDetailRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => "OptionDetails";

        /// <remarks>Overridden to map foreign keys of <seealso cref="OptionDetail"/></remarks>
        /// <inheritdoc />
        protected override T DataRowMapToObject<T>(DataRow dataRow)
        {
            var objectInstance = Activator.CreateInstance<T>();

            //direct column properties
            objectInstance.GetType().GetProperty("Id")!.SetValue(objectInstance, dataRow["Id"]);
            objectInstance.GetType().GetProperty("OptionId")!.SetValue(objectInstance, dataRow["OptionId"] is DBNull ? null : dataRow["OptionId"]);
            objectInstance.GetType().GetProperty("OptionSequence")!.SetValue(objectInstance, dataRow["OptionSequence"] is DBNull ? null : dataRow["OptionSequence"]);
            objectInstance.GetType().GetProperty("Label")!.SetValue(objectInstance, dataRow["Label"]);
            objectInstance.GetType().GetProperty("TranslationId")!.SetValue(objectInstance, dataRow["TranslationId"] is DBNull ? null : dataRow["TranslationId"]);

            //foreign key properties
            objectInstance.GetType().GetProperty("OptionType")!.SetValue(objectInstance,
                (OptionType)(int)dataRow["OptionTypeId"]);

            objectInstance.GetType().GetProperty("Lookup")!.SetValue(objectInstance,
                dataRow["LookupId"] is int ? new OptionLookupRepository().GetById((int)dataRow["LookupId"]) : null);

            objectInstance.GetType().GetProperty("EnumGroup")!.SetValue(objectInstance,
                dataRow["EnumGroupId"] is int ? new OptionEnumGroupRepository().GetById((int)dataRow["EnumGroupId"]) : null);

            objectInstance.GetType().GetProperty("Grouping")!.SetValue(objectInstance,
                new OptionGroupingRepository().GetById((int)dataRow["TreeListGroupId"]));

            return objectInstance;
        }

        /// <remarks>
        ///     Overridden to map foreign keys of <seealso cref="OptionDetail"/><br/>
        ///     Does not handle cascade inserts to other tables.
        /// </remarks>
        /// <inheritdoc />
        protected override string Insert<T>(T insertObject)
        {
            throw new NotImplementedException();
        }

        //TODO: write cascade insert method

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionDetail"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        public IEnumerable<OptionDetail> GetAll() => GetAll<OptionDetail>();

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionDetail"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        public OptionDetail GetById(int id) => GetById<OptionDetail>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionDetail"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionDetail insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionDetail"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionDetail deleteObject) => Delete(deleteObject.Id);
    }
}