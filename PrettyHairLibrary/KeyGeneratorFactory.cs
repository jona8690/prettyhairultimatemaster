using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary {
	public enum KeyGenerators {
		Date, Entity, Random
	}

	public class KeyGeneratorFactory {

		public IKeyGenerator Get(KeyGenerators KG) {
			switch(KG) {
				case KeyGenerators.Date: return KeyGeneratorDate.Instance;
				case KeyGenerators.Entity: return KeyGeneratorEntity.Instance;
				case KeyGenerators.Random: return KeyGeneratorRandom.Instance;
				default: throw new Exception();
			}
		}

	}
}
