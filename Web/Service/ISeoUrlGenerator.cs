//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="ISeoUrlGenerator.cs" company="KOLF s.r.o.">
////   Lékárna KOLF s.r.o.
//// </copyright>
//// <summary>
////   The SeoUrlGenerator interface.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//namespace Erzasoft.Service
//{
//    using System.Diagnostics.Contracts;

//    using Erzasoft.DependecyInterface;

//    /// <summary>
//    /// The SeoUrlGenerator interface.
//    /// </summary>
//    [ContractClass(typeof(SeoUrlGeneratorContract))]
//    public interface ISeoUrlGenerator : IDependency
//    {
//        /// <summary>
//        /// The convert.
//        /// </summary>
//        /// <param name="text">
//        /// The text.
//        /// </param>
//        /// <param name="maxLength">
//        /// The max length.
//        /// </param>
//        /// <returns>
//        /// The System.String.
//        /// </returns>
//        string Convert(string text, int maxLength = 50);
//    }

//    /// <summary>
//    /// The seo url generator contract.
//    /// </summary>
//    [ContractClassFor(typeof(ISeoUrlGenerator))]
//    internal abstract class SeoUrlGeneratorContract : ISeoUrlGenerator
//    {
//        /// <summary>
//        /// The convert.
//        /// </summary>
//        /// <param name="text">
//        /// The text.
//        /// </param>
//        /// <param name="maxLength">
//        /// The max length.
//        /// </param>
//        /// <returns>
//        /// The <see cref="string"/>.
//        /// </returns>
//        public string Convert(string text, int maxLength = 50)
//        {
//            Contract.Requires(text != null);
//            Contract.Requires(maxLength > 0);
//            Contract.Ensures(Contract.Result<string>() != null);

//            return default(string);
//        }
//    }
//}
