using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.PoznaniImport.Services
{
    /// <summary>
    /// The message service.
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// The list of messages.
        /// </summary>
        private readonly List<IMessage> listOfMessages = new List<IMessage>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Add(IMessage message)
        {            
            this.listOfMessages.Add(message);
        }

        /// <summary>
        /// The get messages.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IMessage> GetMessages(string key)
        {
            return this.listOfMessages.Where(s => s.Key == key);
        }

        /// <summary>
        /// The has any.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool HasAny()
        {
            return this.listOfMessages.Any();
        }
    }
}
