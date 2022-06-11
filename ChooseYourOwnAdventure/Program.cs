using System;

namespace Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product()
            {
                Name = "Kitab",
                
            };

            Product product2 = new Product()
            {
                Name = "Stol",
                
            };

            Product product3 = new Product()
            {
                Name = "Spirt",
                
            };

            Product[] productList = new Product[] { product1, product2, product3 };

            string answer = " ";

            

            do
            {
                Console.WriteLine("1. Ratinglere product elave ele...");
                Console.WriteLine("2. Olan productlara ve ratinglerine bax...");
                Console.WriteLine("3. Productu rate ele...");
                Console.WriteLine("0. Menudan cix...");
                Console.WriteLine("____________________________________");
                Console.WriteLine(" ");
                do
                {
                    Console.Write("Secimini ele....");
                    answer = Console.ReadLine();

                } while ((answer != "1" && answer != "2" && answer != "3" && answer != "0") || answer == null);

                switch (answer)
                {
                    case "1":
                        AddProduct(ref productList);
                        Console.WriteLine("Productun elave olundu..");
                        break;

                    case "2":
                        Console.WriteLine("---------------------------------");
                        ShowProducts(productList);
                        Console.WriteLine("---------------------------------");
                        break;

                    case "3":
                        Console.WriteLine("Hansi productu rate elemek isteyirsen?");
                        ShowProducts(productList);
                        string wantedProductStr = Console.ReadLine();
                        bool wantedBool = int.TryParse(wantedProductStr, out int wantedProduct);
                        string answerRatingStr;
                        if (wantedBool == true)
                        {
                            for (int i = 0; i < productList.Length; i++)
                            {
                                if (wantedProduct == productList[i].uniqueID)
                                {
                                    Console.Write("Neche rating vermek isteyirsen?(1 - 5)...");
                                    answerRatingStr = Console.ReadLine();
                                    bool checkRating = double.TryParse(answerRatingStr, out double answerRating);
                                    if (/*checkRating == true &&*/ answerRating>=0 && answerRating<=5)
                                    {
                                        Array.Resize(ref productList[i].RatingList, productList[i].RatingList.Length + 1);
                                        productList[i].RatingList[productList[i].RatingList.Length - 1] = answerRating;
                                        Console.WriteLine(productList[i].Rating); 
                                        Console.WriteLine("Rating elave olundu...");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Daxil elediyin deyer duzgun deyil yeniden yoxla...");
                                        goto case "3";
                                        
                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Daxil elediyin deyer duzgun deyil yeniden yoxla...");
                            goto case "3";
                        }
                        break;


                    default:
                        break;
                }

                

            } while (answer != "0");
        }

        public static Product[] AddProduct(ref Product[] productos)
        {
            Product product = new Product();

            Console.Write("Productun adini yaz...");
            string productName = Console.ReadLine();

            Console.Write("Productun ratingini yaz...");
            string productRatingStr = Console.ReadLine();

            bool checkParse = double.TryParse(productRatingStr, out double productRating);

            if (!string.IsNullOrWhiteSpace(productName) && !string.IsNullOrWhiteSpace(productRatingStr) && checkParse == true)
            {

                product.Name = productName;
                product.Rating = productRating;

                Array.Resize(ref productos, productos.Length + 1);
                productos[productos.Length - 1] = product;
                
            }
            return productos;

        }

        public static void ShowProducts(Product[] productos)
        {
            
            foreach (var product in productos)
            {
                
                Console.WriteLine($"{product.uniqueID}. Product: {product.Name}, Rating: {product.Rating} ");
            }
        }
    }
}

