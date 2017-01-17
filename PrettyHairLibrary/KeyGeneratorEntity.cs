using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary {
	[Serializable]
	class KeyGeneratorEntity : IKeyGenerator {

		// Singleton
		private static volatile KeyGeneratorEntity instance;
		public static KeyGeneratorEntity Instance {
			get {
				if(instance == null) {
					instance = new KeyGeneratorEntity();
				}

				return instance;
			}
		}
		private KeyGeneratorEntity() { }

		private int nextKey;

		public virtual int NextKey {
			get { return ++nextKey; }
		}

	}
}
