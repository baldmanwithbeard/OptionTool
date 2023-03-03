using System.Collections.Generic;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionLookup"/>.
    /// </summary>
    public class OptionLookupRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => "OptionLookups";

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionLookup"/>.</remarks>
        public OptionLookup GetById(int id) => GetById<OptionLookup>(id);

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionLookup"/>.</remarks>
        public IEnumerable<OptionLookup> GetAll() => GetAll<OptionLookup>();

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionLookup"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionLookup insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionLookup"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionLookup deleteObject) => Delete(deleteObject.Id);

        //public bool UpdateOptionLookup(int id, char lookupObjectName)
        //{
        //    var query = $"UPDATE {TableName} SET lookupObjectName = {lookupObjectName} WHERE Id = {id}";
        //    return false;
        //}
    }
}