using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject {
	class Account {
		private static int nextAccountNumber = 100;
		private const int incrementAccountNumber = 70;
		private double Balance = 0;
		private string Name = "My Checking";
		private int Number = 0; //Needs to be set to a proper value yet.

		public double CheckBalance() {
			return Balance;
		}
		public void Debug(string message) {
			Console.WriteLine(message);
		}
		public void Deposit(double amount) {
			//When running an if statement like this, we could have written, IsAmountInvalid(amount) == true, but
			//simply typing IsAmountInvalid(amount) amounts to the same thing.  Had we needed to write an if
			//for IsAmountInvalid(amount) == false, we could have written !IsAmountInvalid(amount), instead.
			if (IsAmountInvalid(amount)) {
				Debug($"The requested amount, {amount}, was not greater than zero. Please enter an amount ");
				Debug($"greater than zero.");
				//While we could have used an "else" to adjust the Balance, if there were a bunch of other things
				//we would need to do if IsAmountInvalid(amount) == false, that would be messier than it
				//has any business being.  For that reason, we just "return" from this method.
				return;
			}
			Balance += amount;			
		}
		private bool IsAmountInvalid(double amount) {
			if (amount > 0) {
				return false;
			}
			else {
				return true;
			}
		}
		public void Withdraw(double amount) {
			if (IsAmountInvalid(amount)) {
				Debug($"The requested amount, {amount}, was not greater than zero. Please enter an amount ");
				Debug($"greater than zero.");
				return;
			}
				if (amount > Balance) {
				Debug($"This transaction has been cancelled, the requested withdraw {amount}");
				Debug($"exceeded the available balance of {Balance}");
				return;
			}
			Balance -= amount;
		}
		public void SetName(string name) {
			Name = name;
		}
		public string GetName() {
			return Name;
		}
		private void SetNumber(int number) {
			Number = number;
		}
		public int GetNumber() {
			return Number;
		}

		public Account() {
			Number = nextAccountNumber;
			nextAccountNumber += incrementAccountNumber;
;
		}
		public Account(string name) {
			Name = name;
			Number = nextAccountNumber;
			nextAccountNumber += incrementAccountNumber;
		}
	}
}
