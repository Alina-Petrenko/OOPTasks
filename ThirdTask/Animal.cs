using System;

namespace ThirdTask
{
    /// <summary>
    /// Provides gender of animals
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    // TODO: Before
    // TODO: compare structure of classes and properties in "Before" and "After"
    /// <summary>
    /// Class represents animal
    /// </summary>
    //public abstract class Animal
    //{
    //    private int age;
    //    private int speed;
    //    public string Name { get; protected set; }
    //    public int Age
    //    {
    //        get
    //        {
    //            return age;
    //        }
    //        protected set
    //        {
    //            if (value <= 0)
    //            {
    //                throw new ArgumentOutOfRangeException("Age can't be less then 0");
    //            }
    //            else
    //            {
    //                age = value;
    //            }
    //        }
    //    }
    //    public int PawCount { get; protected set; }
    //    public Gender Gender { get; protected set; }
    //    public int Speed
    //    {
    //        get
    //        {
    //            return speed;
    //        }
    //        protected set
    //        {
    //            if (value <= 0)
    //            {
    //                throw new ArgumentOutOfRangeException("Speed can't be less then 0");
    //            }
    //            else
    //            {
    //                speed = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Сhecks the received speed for compliance with the limit
    //    /// </summary>
    //    /// <param name="speed">Received speed</param>
    //    /// <returns>Returns speed</returns>
    //    /// <exception cref="OverSpeedException">Over speed for animal</exception>
    //    public abstract int SpeedCheck(int speed);
    //}

    // TODO: After
    /// <summary>
    /// Class represents animal.
    /// </summary>
    public abstract class Animal
    {
        #region Fields

        /// <summary>
        /// Age
        /// </summary>
        private int _age;

        /// <summary>
        /// Maximum speed
        /// </summary>
        private int _speed;
        #endregion

        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Count of paw
        /// </summary>
        public int PawCount { get; protected set; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; protected set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age
        {
            get => _age;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Age));
                }

                _age = value;
            }
        }

        /// <summary>
        /// Maximum speed
        /// </summary>
        public int Speed
        {
            get => _speed;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Speed));
                }

                _speed = value;
            }
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Сhecks the received speed for compliance with the limit.
        /// </summary>
        /// <param name="speed">Received speed</param>
        /// <returns>Returns speed</returns>
        /// <exception cref="OverSpeedException">Thrown when animal tried to over speed</exception>
        public abstract int SpeedCheck(int speed);

        #endregion
    }
}
