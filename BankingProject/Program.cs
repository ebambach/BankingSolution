using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject {
	class Program {
		static void Main(string[] args) {
			new Program().Run();
		}
		void Run() {
			Account checking = new Account("My Checking");
			Account savings = new Account("My Savings");
			checking.Deposit(100.00);
			checking.Withdraw(20.00);
			Console.WriteLine($"Account # {checking.GetNumber()}, Name: {checking.GetName()} has a balance of {checking.CheckBalance()}.");
			savings.Deposit(350);
			Console.WriteLine($"Account # {savings.GetNumber()}, Name: {savings.GetName()} has a balance of {savings.CheckBalance()}.");
			savings.Transfer(340, checking);
			Console.WriteLine($"Account # {checking.GetNumber()}, Name: {checking.GetName()} has a balance of {checking.CheckBalance()}.");
			Console.WriteLine($"Account # {savings.GetNumber()}, Name: {savings.GetName()} has a balance of {savings.CheckBalance()}.");



		}
	}
}
