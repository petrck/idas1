namespace Erzasoft.DataModel.Semestralka
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The image.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the image id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        public virtual string Source { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is main.
        /// </summary>
        public virtual bool IsMain { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public virtual int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public virtual int Height { get; set; }

        ///// <summary>
        ///// Gets or sets the senior.
        ///// </summary>
        [ForeignKey("Product")]
        public virtual int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}