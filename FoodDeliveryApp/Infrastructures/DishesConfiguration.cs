using FoodDeliveryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructures
{
    public class DishesConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasData(CreateDishes());
        }

        private List<Dish> CreateDishes()
        {
            var dishes = new List<Dish>()
            {
                //TODO THERE IS PROBLEM WITH DISHES SEEDING. FIND WHATS GOING ON!
                //new Dish()
                //{
                //    Id = 1,
                //    Name = "Spinach salad with polenta croutons",
                //    Descriprion = "Delicate spinach leaves with cherry tomato, red peppers, red onion, dried tomatoes, flavored with lemon dressing and garnished with spinach croutons croutons 310g",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP.6O4lSV6cu5Ra_3YVAvRP0AHaE8&pid=Api",
                //    Price = 12.10m,
                //    MenuId = 1,
                //    RestaurantId =1
                //},
                //new Dish()
                //{
                //    Id = 2,
                //    Name = "Mix salads with Avocado dressing",
                //    Descriprion = "Mix of garden salads and cherry tomatoes, with avocado dressing (avocado, cucumber, red onion, olive oil, fresh lemon) and parmesan flakes. 250г",
                //    DishImage = "https://tse4.mm.bing.net/th?id=OIP.LGvci-OyPVjLMOVIFcrBQQHaE7&pid=Api",
                //    Price = 11.40m,
                //    MenuId = 1,
                //    RestaurantId = 1
                //},

                //new Dish()
                //{
                //    Id = 3,
                //    Name = "Guacamole",
                //    Descriprion = "Classic recipe with avocado, fresh lime and lemon, tabasco, coriander, white pepper, salt and olive oil. 210г",
                //    DishImage = "https://tse1.mm.bing.net/th?id=OIP.ppPPXvothyhF3VMy5nvdHgHaFj&pid=Api",
                //    Price = 12.90m,
                //    MenuId = 1,
                //    RestaurantId =1
                //},

                //new Dish()
                //{
                //    Id = 4,
                //    Name = "Chinque Formaggi",
                //    Descriprion = "Unique Italian dough of your choice, Gentle symphony of cheese (Ricotta, blue cheese, mozzarella, cheddar, goat cheese - ripe), cherry tomatoes, white oregano and fresh fresh garden basil 520g",
                //    DishImage = "https://tse1.mm.bing.net/th?id=OIP.ql8SL07fNaC6nSbDe-0VVwHaE7&pid=Api",
                //    Price = 18.10m,
                //    MenuId = 3,
                //    RestaurantId =1
                //},
                //new Dish()
                //{
                //    Id = 5,
                //    Name = "Fungi with truffle cream",
                //    Descriprion = "Unique Italian dough of your choice with cream base, Bulgarian black Truffle, wild mushrooms and mozzarella 470g",
                //    DishImage = "https://tse3.mm.bing.net/th?id=OIP.mfb3S2P4oMsXN12CZ6alhgHaE8&pid=Api",
                //    Price = 11.40m,
                //     MenuId = 3,
                //    RestaurantId =1
                //},

                //new Dish()
                //{
                //    Id = 6,
                //    Name = "Vegetable Chaat",
                //    Descriprion = "Vegetarian salad with cucumbers, tomatoes, peppers, lettuce, potatoes and Indian spices (400 g)",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP.thlfF5hFpjKC1jcQKdme_QHaE8&pid=Api",
                //    Price = 18.11m,
                //    MenuId = 1,
                //    RestaurantId =2
                //},
                //new Dish()
                //{
                //    Id = 7,
                //    Name = "Chana chaat new recipe",
                //    Descriprion = "Salad of chickpeas, tomatoes, onions, mint, flavored with lemon and chat masala. Typical Indian salad (400 g)",
                //    DishImage = "https://tse3.mm.bing.net/th?id=OIP.xMIF4_wVi98ZqRtEqP4fZAHaHa&pid=Api",
                //    Price = 12.40m,
                //    MenuId = 1,
                //    RestaurantId =2
                //},

                //new Dish()
                //{
                //    Id = 8,
                //    Name = "Pappadums(2 pcs.)",
                //    Descriprion = "Crispy fried Indian chips served with mango chutney sauce",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP.cncO9Lf5KTa6uMKLqPtrVQHaD4&pid=Api",
                //    Price = 6.10m,
                //    MenuId = 5,
                //    RestaurantId =2
                //},

                //new Dish()
                //{
                //    Id = 9,
                //    Name = "Tandoori Chicken",
                //    Descriprion = "Chicken drum sticks marinated in masala spices and cooked to perfection in a traditional tandoori oven (400 g)",
                //    DishImage = "https://tse3.mm.bing.net/th?id=OIP.ye25qeN1mFw2vN4dNbZeWwHaE7&pid=Api",
                //    Price = 20.11m,
                //     MenuId = 6,
                //    RestaurantId =2
                //},
                //new Dish()
                //{
                //    Id = 10,
                //    Name = "Sikh kebab (medium hot)",
                //    Descriprion = "A sausage like shaped minced lamb grilled on a skewer in a Tandoor oven (400 g)",
                //    DishImage = "https://tse4.mm.bing.net/th?id=OIP.bSf7AGhYpOZinLWveT8z3QHaHa&pid=Api",
                //    Price = 24.40m,
                //    MenuId = 6,
                //    RestaurantId =2
                //},

                //new Dish()
                //{
                //    Id = 11,
                //    Name = "Chicken Lunch Box",
                //    Descriprion = "150 g. Chicken Strips + small french fries with ranch sauce - 300 g",
                //    DishImage = "https://tse3.mm.bing.net/th?id=OIP.xe4Muq3LT1qVkO3R08i0bwHaE8&pid=Api",
                //    Price = 12.00m,
                //    MenuId = 7,
                //    RestaurantId =3
                //},
                //new Dish()
                //{
                //    Id = 12,
                //    Name = "EASY LUNCH BOX",
                //    Descriprion = "Easy like sunday morning burger + small french fries with ranch sauce - 390 g",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP._BYj0CZ-S5ZzTxWcQc5_aAHaDt&pid=Api",
                //    Price = 13.40m,
                //    MenuId = 7,
                //    RestaurantId =3
                //},

                //new Dish()
                //{
                //    Id = 13,
                //    Name = "El Pollo Loco",
                //    Descriprion = "Roasted at night brioche bread, breaded to golden chicken fillet, crispy bacon, freshly chopped tomato and fresh iceberg lettuce, pickles, mayonnaise and mustard and homemade BBQ sauce.",
                //    DishImage = "https://tse4.mm.bing.net/th?id=OIP.QFeleKqVKygTPaQA3c4yeQHaD2&pid=Api",
                //    Price = 15.00m,
                //    MenuId = 8,
                //    RestaurantId =3
                //},
                //new Dish()
                //{
                //    Id = 14,
                //    Name = "Beef burger",
                //    Descriprion = "100% ground beef, cheddar mayonnaise with black garlic, BBQ sauce, iceberg, jalapeno, pickled red onion",
                //    DishImage = "https://tse3.mm.bing.net/th?id=OIP.zxiJIpvmvPW0CAOos6lEmwHaE8&pid=Api",
                //    Price = 16.40m,
                //    MenuId = 8,
                //    RestaurantId =3
                //},

                //new Dish()
                //{
                //    Id = 15,
                //    Name = "Nigiri salmon",
                //    Descriprion = "(65g) rice, salmon; wasabi; ginger; soy sauce 2pcs",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP.RE2JBaTV0d-MR9qracAqMQHaE5&pid=Api",
                //    Price = 5.99m,
                //    MenuId = 9,
                //    RestaurantId =5
                //},

                //new Dish()
                //{
                //    Id = 16,
                //    Name = "Hosomaki cucumber",
                //    Descriprion = "(110g) rice, nori, cucumber, sesame mix; wasabi; ginger; soy sauce 8pcs",
                //    DishImage = "https://tse2.mm.bing.net/th?id=OIP.7JLUvfUC2918ZtaFayFOGQHaEG&pid=Api",
                //    Price = 4.59m,
                //    MenuId = 10,
                //    RestaurantId =3
                //},

                //new Dish()
                //{
                //    Id = 17,
                //    Name = "Uramaki Philadelphia tuna",
                //    Descriprion = "(90g) rice, nori, tuna, philadelphia, cucumber, yukari; wasabi; ginger; soy sauce 4pcs",
                //    DishImage = "https://tse4.mm.bing.net/th?id=OIP.xe8_9TSNtoRx6D_GpG_c1AHaFj&pid=Api",
                //    Price = 5.99m,
                //    MenuId = 11,
                //    RestaurantId =3
                //}
            };
            return dishes;
        }
    }
}

