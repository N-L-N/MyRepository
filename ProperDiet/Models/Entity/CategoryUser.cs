using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Models.Entity
{
    public class CategoryUser
    {

        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание категории.
        /// </summary>
        public string Description { get; set; }

        public int UserId { get; set; }

    }
}
