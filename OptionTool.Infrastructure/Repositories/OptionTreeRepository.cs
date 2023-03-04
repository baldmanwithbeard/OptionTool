using System.Collections.Generic;
using OptionTool.Domain.Entities;

namespace OptionTool.Infrastructure.Repositories
{
    /// <summary>
    ///     Contains data layer for <seealso cref="OptionTree"/>.
    /// </summary>
    public class OptionTreeRepository : BaseEntityRepository
    {
        /// <inheritdoc />
        protected override string TableName => TableNames.OptionTree;

        /// <inheritdoc cref="BaseEntityRepository.GetAll{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetAll{T}"/>, specifying type as <seealso cref="OptionTree"/>.</remarks>
        public IEnumerable<OptionTree> GetAll() => GetAll<OptionTree>();

        /// <inheritdoc cref="BaseEntityRepository.GetById{T}"/>
        /// <remarks>Wraps <seealso cref="BaseEntityRepository.GetById{T}"/>, specifying type as <seealso cref="OptionTree"/>.</remarks>
        public OptionTree GetById(int id) => GetById<OptionTree>(id);

        /// <remarks>Wraps <seealso cref="BaseEntityRepository.Insert{T}"/>, specifying type as <seealso cref="OptionTree"/>.</remarks>
        /// <inheritdoc cref="BaseEntityRepository.Insert{T}"/>
        public string Insert(OptionTree insertObject) => base.Insert(insertObject);

        /// <summary>
        ///     Calls <seealso cref="BaseEntityRepository.Delete"/>, deletes passed <see cref="OptionTree"/> instance's corresponding record from database.
        /// </summary>
        /// <param name="deleteObject"> instance to be deleted </param>
        public string Delete(OptionTree deleteObject) => Delete(deleteObject.Id);
    }
}