using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PrettyHairLibrary {
	public class KeyGeneratorDate : IKeyGenerator {

		// Singleton
		private static volatile KeyGeneratorDate instance;
		public static KeyGeneratorDate Instance {
			get {
				if (instance == null) {
					instance = new KeyGeneratorDate();
				}

				return instance;
			}
		}
		private KeyGeneratorDate() { }

		List<int> UsedKeys = new List<int>();

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
		private int GetAKey() {
			DateTime now = DateTime.Now;
			
			return now.Year + now.Month + now.Day
				 + now.Hour + now.Minute + now.Second + now.Millisecond;
		}
	}
}
