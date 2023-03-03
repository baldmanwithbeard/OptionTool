using System.Collections.Generic;
using SampleSolution.Domain.Entities;

namespace SampleSolution.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionEnumItem"/>.
    /// </summary>
    public class OptionEnumItemRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => "OptionEnumItems";

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionEnumItem"/>.</remarks>
        // ReSharper disable once UnusedMember.Global
        public IEnumerable<OptionEnumItem> GetAll() => GetAll<OptionEnumItem>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionEnumItem"/>.</remarks>
        public OptionEnumItem GetById(int id) => GetById<OptionEnumItem>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionEnumItem"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionEnumItem insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionEnumItem"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionEnumItem deleteObject) => Delete(deleteObject.Id);
    }
}