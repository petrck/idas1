using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.PoznaniImport.Services
{
    using Erzasoft.DependecyInterface;

    /// <summary>
    /// The MessageService interface.
    /// </summary>
    public interface IMessageService : IDependency
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Add(IMessage message);

        /// <summary>
        /// The get messages.
        /// </summary>
        /// <param name="key">
        /// The Key.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IMessage> GetMessages(string key);

        /// <summary>
        /// The has any.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool HasAny();
    }
}
