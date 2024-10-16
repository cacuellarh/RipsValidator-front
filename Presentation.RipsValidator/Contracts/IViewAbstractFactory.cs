

using System.Windows.Controls;

namespace Presentation.RipsValidator.Contracts
{
    public interface IAbstractFactory<T>
    {
        public T Create();
    }
}
