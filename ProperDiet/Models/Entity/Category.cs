using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Entity
{
    public class Category
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

        /// <summary>
        /// Список продуктов, относящихся к данной категории.
        /// </summary>
        public List<Food> Foods { get; set; } = new List<Food>();
    }
}
