using System.Collections.Generic;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="ValueLookupObject"/>.
    /// </summary>
    public class ValueLookupObjectRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => TableNames.OptionLookup;

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="ValueLookupObject"/>.</remarks>
        public ValueLookupObject GetById(int id) => GetById<ValueLookupObject>(id);

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="ValueLookupObject"/>.</remarks>
        public IEnumerable<ValueLookupObject> GetAll() => GetAll<ValueLookupObject>();

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="ValueLookupObject"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(ValueLookupObject insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="ValueLookupObject"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(ValueLookupObject deleteObject) => Delete(deleteObject.Id);

        //public bool UpdateOptionLookup(int id, char lookupObjectName)
        //{
        //    var query = $"UPDATE {TableName} SET lookupObjectName = {lookupObjectName} WHERE Id = {id}";
        //    return false;
        //}
    }
}