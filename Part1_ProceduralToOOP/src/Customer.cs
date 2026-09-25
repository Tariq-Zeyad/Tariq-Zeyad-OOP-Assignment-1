namespace Object_OrientedOOP.Part1_ProceduralToOOP.src
{
    public class Customer
    {
        private int _id;
        private string _name;
        private string _email;
        private string _city;
        private bool _isVip;


        public int Id
        {
            get { return _id; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Id must be greater than 0");

                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                    throw new ArgumentException("Invalid email");

                _email = value;
            }
        }

        public string City
        {
            get { return _city; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("City cannot be empty");

                _city = value;
            }
        }

        public bool IsVip
        {
            get { return _isVip; }
            private set
            {
                _isVip = value;
            }
        }
        public Customer(int id, string name, string email, string city, bool isVip)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangeCity(string city)
        {
            City = city;
        }
    }
}