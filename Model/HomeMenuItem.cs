using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// The different pages available from the menu
    /// </summary>
    public enum MenuItemType
    {
        ComposeMenus,
        CheckMenus,
        About
    }

    /// <summary>
    /// Storing class for the item in the menu
    /// </summary>
    public class HomeMenuItem
    {
        /// <summary>
        /// Id of the item page
        /// </summary>
        public MenuItemType Id { get; set; }

        /// <summary>
        /// Title of the item page
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Image of the item page
        /// </summary>
        public string Image { get; set; }
    }
}
