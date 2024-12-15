using ProperDiet.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Entity
{
    public class Food
    {
        /// <summary>
        /// Уникальный идентификатор еды.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание продукта.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Калорийность на 100 г/мл.
        /// </summary>
        public int Calories { get; set; }

        /// <summary>
        /// Идентификатор категории, к которой относится продукт.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
