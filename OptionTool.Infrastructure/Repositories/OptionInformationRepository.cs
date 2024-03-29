﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OptionTool.Domain.Entities;

namespace OptionTool.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionInformation"/>.
    /// </summary>
    public class OptionInformationRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => TableNames.OptionInformation;

        /// <remarks>Overridden to map foreign keys of <seealso cref="OptionInformation"/></remarks>
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
            objectInstance.GetType().GetProperty("OptionValueType")!.SetValue(objectInstance,
                (OptionValueType)(int)dataRow["ValueTypeId"]);

            objectInstance.GetType().GetProperty("ValueLookupObject")!.SetValue(objectInstance,
                dataRow["ValueLookupObjectId"] is int ? new ValueLookupObjectRepository().GetById((int)dataRow["ValueLookupObjectId"]) : null);

            objectInstance.GetType().GetProperty("ValueEnumGroup")!.SetValue(objectInstance,
                dataRow["ValueEnumGroupId"] is int ? new ValueEnumGroupRepository().GetById((int)dataRow["ValueEnumGroupId"]) : null);

            objectInstance.GetType().GetProperty("OptionTree")!.SetValue(objectInstance,
                new OptionTreeRepository().GetById((int)dataRow["OptionTreeId"]));

            return objectInstance;
        }

        /// <remarks>
        ///     Overridden to map foreign keys of <seealso cref="OptionInformation"/><br/>
        ///     Does not handle cascade inserts to other tables.
        /// </remarks>
        /// <inheritdoc />
        protected override string Insert<T>(T insertObject)
        {
            if (insertObject is not OptionInformation insertOptionInformation) throw new ArgumentException("insertObject must be instance of OptionInformation");

            var insertCommand = DatabaseConnection.GetCommandBuilder(TableName).GetInsertCommand(true);
            insertCommand.Parameters["@Id"].Value = insertOptionInformation.Id;
            insertCommand.Parameters["@OptionId"].Value = (object)insertOptionInformation.OptionId ?? DBNull.Value;
            insertCommand.Parameters["@OptionSequence"].Value = (object)insertOptionInformation.OptionSequence ?? DBNull.Value;
            insertCommand.Parameters["@Label"].Value = insertOptionInformation.Label;
            insertCommand.Parameters["@TranslationId"].Value = (object)insertOptionInformation.TranslationId ?? DBNull.Value;
            insertCommand.Parameters["@ValueTypeId"].Value = (int)insertOptionInformation.OptionValueType;
            insertCommand.Parameters["@ValueLookupObjectId"].Value = (object)insertOptionInformation.ValueLookupObject?.Id ?? DBNull.Value;
            insertCommand.Parameters["@ValueEnumGroupId"].Value = (object)insertOptionInformation.ValueEnumGroup?.Id ?? DBNull.Value;
            insertCommand.Parameters["@OptionTreeId"].Value = insertOptionInformation.OptionTree.Id;

            try
            {
                return insertCommand.ExecuteNonQuery() == 1 ? "Created 1 record successfully" : "Failed without exception";
            }
            catch (Exception e)
            {
                return $"Failed with message: {e.Message}";
            }
        }

        //TODO: write cascade insert method

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionInformation"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        public IEnumerable<OptionInformation> GetAll() => GetAll<OptionInformation>();

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionInformation"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        public OptionInformation GetById(int id) => GetById<OptionInformation>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionInformation"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionInformation insertObject) => Insert<OptionInformation>(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionInformation"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionInformation deleteObject) => Delete(deleteObject.Id);
    }
}