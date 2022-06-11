using System;
namespace Rating
{
	public class Product
	{
		public Product()
		{
            RatingList = new double[1];
			countIdentifier++;
			uniqueID = countIdentifier;

		}
		public string Name;
		private double _rating;

		public static int countIdentifier = 0;
		public int uniqueID = 0;
		public double Rating
        {
			get { return _rating; }

            set
            {
				double totalRating = 0;
                foreach (var rating in RatingList)
                {
					totalRating += rating;

                }
				_rating = totalRating / RatingList.Length;

			}
        }
		public double[] RatingList;

		
	}

}

