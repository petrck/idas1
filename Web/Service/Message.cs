// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageService.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   The message service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.PoznaniImport.Services
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The message service.
    /// </summary>
    public class Message : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        /// <param name="block">
        /// The block.
        /// </param>
        /// <param name="text">
        /// The message.
        /// </param>
        /// <param name="typeofMessage">
        /// The typeof Message.
        /// </param>
        private Message(string questionName, string text, Type typeofMessage = Type.Info)
        {
            this.TypeofMessage = typeofMessage;
            this.Text = text;
            this.Key = questionName;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type TypeofMessage { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the block keys.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="block">
        /// The block.
        /// </param>
        /// <param name="text">
        /// The message.
        /// </param>
        /// <param name="typeofMessage">
        /// The typeof message.
        /// </param>
        /// <returns>
        /// The <see cref="IMessage"/>.
        /// </returns>
        public static IMessage Create(string questionName, string text, Type typeofMessage = Type.Info)
        {
            return new Message(questionName, text, typeofMessage);
        }
    }
}
