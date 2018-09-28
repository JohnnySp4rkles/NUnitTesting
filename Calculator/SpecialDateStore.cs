using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    public class SpecialDateStore {
        public DateTime DateOf(SpecialDates specialDate) {
            switch (specialDate) {
                case SpecialDates.NewMillenium:
                    return new DateTime(2000, 1, 1, 0, 0, 0, 0);
                default:
                    throw new ArgumentOutOfRangeException("special date!");
            }
        }
    }

    public enum SpecialDates {
        NewMillenium
    }
}
