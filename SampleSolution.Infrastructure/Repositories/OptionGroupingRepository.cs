using System.Collections.Generic;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionGrouping"/>.
    /// </summary>
    public class OptionGroupingRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => "OptionTreeListGroups";

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionGrouping"/>.</remarks>
        public IEnumerable<OptionGrouping> GetAll() => GetAll<OptionGrouping>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionGrouping"/>.</remarks>
        public OptionGrouping GetById(int id) => GetById<OptionGrouping>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionGrouping"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionGrouping insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionGrouping"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionGrouping deleteObject) => Delete(deleteObject.Id);
    }
}