using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Stormworks_Save_Transfer {
    public class SavePropertyDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate BooleanDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            SaveProperty property = item as SaveProperty;

            if (property.Value == "True" || property.Value == "False")
                return BooleanDataTemplate;
            else
                return DefaultDataTemplate;
        }
    }
}
