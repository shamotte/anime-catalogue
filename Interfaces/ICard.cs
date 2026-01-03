using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.MemoryGame.Interfaces
{
    public interface ICard
    {
        public int Id { get; }
        public string Graphic { get; }

        public int value { get; }

        public bool CompareCard(ICard other);

    }
}
