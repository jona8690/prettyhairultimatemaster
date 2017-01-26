using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary {
	class Facade {
		OrderRepository RepoOrder = OrderRepository.Instance();
		ProductTypeRepository RepoPT = ProductTypeRepository.Instance;
		IKeyGenerator KeyGen = KeyGeneratorFactory.Get(KeyGenerators.Date);

	}
}
