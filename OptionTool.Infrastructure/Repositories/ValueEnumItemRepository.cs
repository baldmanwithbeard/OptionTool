using System.Collections.Generic;
using OptionTool.Domain.Entities;

namespace OptionTool.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="ValueEnumItem"/>.
    /// </summary>
    public class ValueEnumItemRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => TableNames.ValueEnumItem;

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="ValueEnumItem"/>.</remarks>
        // ReSharper disable once UnusedMember.Global
        public IEnumerable<ValueEnumItem> GetAll() => GetAll<ValueEnumItem>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="ValueEnumItem"/>.</remarks>
        public ValueEnumItem GetById(int id) => GetById<ValueEnumItem>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="ValueEnumItem"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(ValueEnumItem insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="ValueEnumItem"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(ValueEnumItem deleteObject) => Delete(deleteObject.Id);
    }
}