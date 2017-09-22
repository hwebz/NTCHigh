using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Validation;
using System.Collections.Generic;

namespace High.Net.Models.Business.SelectionFactory
{
    public class SelectColumnPosition : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>() {
                new SelectItem{Text = "Full", Value=ColumnPosition.FullWidth},
                new SelectItem{Text = "First Column", Value=ColumnPosition.FirstColumn},
                new SelectItem{Text = "Second Column", Value=ColumnPosition.SecondColumn},
                new SelectItem{Text = "Third Column", Value=ColumnPosition.ThirdColumn },
                new SelectItem{Text = "Fourth Column", Value=ColumnPosition.FourthColumn                }
            };
        }
    }
}