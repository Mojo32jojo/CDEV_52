namespace Module_6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
			Console.ReadKey();
		}
	enum TurnDirection
	{
		None = 0,
		Left,
		Right
	}

	class Car
	{
		private double Fuel;

		private int Mileage;

		private string color;

		private TurnDirection turn;

		public Car()
		{
			Fuel = 50;
			Mileage = 0;
			color = "White";
		}

		private void Move()
		{
			// Move a kilometer
			Mileage++;
			Fuel -= 0.5;
		}

		private void Turn(TurnDirection direction)
		{
			turn = direction;
		}

		public void FillTheCar()
		{
			Fuel = 50;
		}

		public string GetColor()
		{
			return color;
		}

		public void ChangeColor(string newColor)
		{
			if (color != newColor)
				color = newColor;
		}

		public bool IsTurningLeft()
		{
			return turn == TurnDirection.Left;
		}

		public bool IsTurningRight()
		{
			return turn == TurnDirection.Right;
		}

		class User
		{
			private int age;
			private string login;
			private string email; 

			public int Age
			{
				get
				{
					return age;
				}

				set
				{
					if (value < 18)
					{
						Console.WriteLine("Возраст должен быть не меньше 18");
					}
					else
					{
						age = value;
					}
				}
			}
			public string Login
			{
				get
				{
					return login;
				}
				
				set
				{
					if (login.Length <= 3)
					{
						Console.WriteLine("Логин должен быть не короче 3 символов");
					}
					else 
					{
						login = value;
					}
				}
			}
			public string Email
			{
				get
				{
					return email;
				}
				set
				{	
					bool b = value.Contains('@'); 
					if (b != true)
					//if (!value.Contains('@'))
					{
						Console.WriteLine("В адресе почты нет символа '@'");
					}
					else
					{
						email = value;
					}
				}
			}
			
		}
	

	}
	}
}