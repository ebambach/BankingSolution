using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//^Unlike the Savings class, we don't need to add any more "using," because Account is not
//inheriting any other classes.  Because Savings does inherit Account, there we need to use
//"using BankingProject;"


namespace BankingProject {
	public class Account {
		//What the next Account number created by the program be
		private static int nextAccountNumber = 100;
		//How much the next Account number will be incremented by
		private const int incrementAccountNumber = 70;
		//A default Balance of 0 is given to an Account upon creation
		protected double Balance = 0;
		//A default Name of "My Checking" is given to an Account, upon creation, unless another Name
		//is specified.
		private string Name = "My Checking";
		//A default Account number that nextAccountNumber is added to
		private int Number = 0;

		//Returns the current value of the double, Balance.  Balance stores how much money is in an
		//Account.
		public double CheckBalance() {
			return Balance;
		}
		/// <summary>
		/// This method prints the "message" to the Console.
		/// </summary>
		/// <param name="message"></param>
		public void Debug(string message) {
			Console.WriteLine(message);
		}
		/// <summary>
		/// The Deposit function can be called as a stand alone method, or as part of the "Transfer" method.
		/// In the event that the "amount" is less than or equal to zero, it passes a "message" to Debug,
		/// and returns false.  If the "amount" is greater than zero, the "amount" is added to the "Balance,"
		/// and the method returns true.
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public bool Deposit(double amount) {
			//When running an if statement like this, we could have written, IsAmountInvalid(amount) == true, but
			//simply typing IsAmountInvalid(amount) amounts to the same thing.  Had we needed to write an if
			//for IsAmountInvalid(amount) == false, we could have written !IsAmountInvalid(amount), instead.
			if (IsAmountInvalid(amount)) {
				Debug($"The requested amount, {amount}, was not greater than zero. Please enter an amount ");
				Debug($"greater than zero.");
				//While we could have used an "else" to adjust the Balance, if there were a bunch of other things
				//we would need to do if IsAmountInvalid(amount) == false, that would be messier than it
				//has any business being.  For that reason, we just "return" from this method.
				return false;
			}
			Balance += amount;
			return true;
		}
		/// <summary>
		/// This method confirms that the "amount" > 0.
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		private bool IsAmountInvalid(double amount) {
			if (amount > 0) {
				return false;
			}
			else {
				return true;
			}
		}
		//The next four methods are all about setting and getting the names and numbers of the account.
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
		//Instead of calling Debug, to which we can pass any string, ToPrint is used by Account
		//to always return a specific interpolated message to the Console when the Program calls
		//"Console.WriteLine(account.ToPrint())"
		//ToPrint is virtual, because Savings needs to be able to "override" ToPrint, so that Savings
		//is able to add the IntRate to the returned string.
		public virtual string ToPrint() {
			return $"Account {Number}: '{Name}' has a balance of {Balance}";
		}

		public bool Transfer(double amount, Account toAccount) {
			//In the Program example, we used savings.Transfer() to call this method.  By using this.Withdraw(),
			//C# knows to substitute "this" with "savings." (We could also do just Withdraw(), without "this,"
			//and our program functions in the same manner.)
			if (Withdraw(amount)) {
				toAccount.Deposit(amount);
				return true;
			}
			else {
				return false;
			}
		}
		public bool Withdraw(double amount) {
			if (IsAmountInvalid(amount)) {
				Debug($"The requested amount, {amount}, was not greater than zero. Please enter an amount ");
				Debug($"greater than zero.");
				return false;
			}
			if (amount > Balance) {
				Debug($"This transaction has been cancelled, the requested withdraw {amount}");
				Debug($"exceeded the available balance of {Balance}");
				return false;
			}
			Balance -= amount;
		return true;
		}

		//This is the substitute default Account constructor when no values are being passed to it.
		//We need to add one of these because of the original default constructor is not added by .NET
		//when we have the additional constructor below this one.
		//Both constructors provide the account with a Number, and increment the value used to
		//provide that number, making sure that each Number is unique.
		public Account() {
			Number = nextAccountNumber;
			nextAccountNumber += incrementAccountNumber;
;
		}
		//When this constructor is given a name to use as the account's "Name," this constructor gets
		//called instead of the previous.
		public Account(string name) {
			Name = name;
			Number = nextAccountNumber;
			nextAccountNumber += incrementAccountNumber;
		}
	}
}
