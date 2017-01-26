using System;
using System.Collections.Generic;

namespace PrettyHairLibrary {
	class KeyGeneratorRandom : IKeyGenerator {
		
		// Singleton
		private static volatile KeyGeneratorRandom instance;
		public static KeyGeneratorRandom Instance {
			get {
				if (instance == null) {
					instance = new KeyGeneratorRandom();
				}

				return instance;
			}
		}
		private KeyGeneratorRandom() { }

		private List<int> UsedKeys = new List<int>();
		public int NextKey {
			get {
				int Key;

				do { // If key has been used, run again.
					Key = GetAKey();
				} while (UsedKeys.Contains(Key));

				UsedKeys.Add(Key);

				return Key;
			}
		}

		public int GetAKey() {
			Random rnd0 = new Random();
			Random rnd1 = new Random();
			Random rnd2 = new Random();
			Random rnd3 = new Random();
			Random rnd4 = new Random();

			int Key = rnd0.Next(1, 1000);
			if (Key % 2 == 0) {
				Key += rnd1.Next(75, 100);
			}

			if (rnd2.Next(1, 3) == 1) {
				Key += rnd3.Next(1, 1000);
			}

			Key += rnd4.Next(1, 10000);

			return Key;
		}
	}
}
