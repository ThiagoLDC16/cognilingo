namespace Cognilingo.Infrastructure.Common.Persistence;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedUsersAsync(context);
        await SeedSimulationDataAsync(context);
    }

    private static async Task SeedUsersAsync(ApplicationDbContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var hasher = new MD5PasswordHasher();
        var user = new User(
            "Admin",
            "admin@teste.com",
            hasher.Hash("admin123")
        );

        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    private static async Task SeedSimulationDataAsync(ApplicationDbContext context)
    {
        if (await context.Categories.AnyAsync()) return;

        // 1. Categories
        var socialCategory = new Category(icon: "https://example.com/social.png");
        socialCategory.AddTranslation("en", "Social");
        socialCategory.AddTranslation("pt-BR", "Social");

        var travelCategory = new Category(icon: "https://example.com/travel.png");
        travelCategory.AddTranslation("en", "Travel");
        travelCategory.AddTranslation("pt-BR", "Viagem");

        var workCategory = new Category(icon: "https://example.com/work.png");
        workCategory.AddTranslation("en", "Work");
        workCategory.AddTranslation("pt-BR", "Trabalho");

        context.Categories.AddRange(socialCategory, travelCategory, workCategory);
        await context.SaveChangesAsync();

        // 2. Situations (Social)
        var coffeeSituation = new Situation(socialCategory.Id);
        coffeeSituation.AddTranslation("en", "Ordering Coffee", "A common situation at a coffee shop.");
        coffeeSituation.AddTranslation("pt-BR", "Pedindo Café", "Uma situação comum em uma cafeteria.");

        context.Situations.Add(coffeeSituation);
        await context.SaveChangesAsync();

        // 3. Situation Variants
        var coffeeEnVariant = new SituationVariant(
            coffeeSituation.Id,
            learningLanguage: "en",
            promptInstructions: "You are a barista at a busy London coffee shop. Be polite but efficient.",
            initialMessage: "Hello! Welcome to CogniCoffee. What can I get for you today?"
        );
        coffeeEnVariant.AddTranslation("en", "Coffee Shop in London", "You are at a coffee shop in London.");
        coffeeEnVariant.AddTranslation("pt-BR", "Cafeteria em Londres", "Você está em uma cafeteria em Londres.");

        context.SituationVariants.Add(coffeeEnVariant);
        await context.SaveChangesAsync();

        // 4. Objectives
        var objective1 = new SituationVariantObjective(coffeeEnVariant.Id);
        objective1.AddTranslation("en", "Greet the barista");
        objective1.AddTranslation("pt-BR", "Cumprimentar o atendente");

        var objective2 = new SituationVariantObjective(coffeeEnVariant.Id);
        objective2.AddTranslation("en", "Order a specific type of coffee");
        objective2.AddTranslation("pt-BR", "Pedir um tipo específico de café");

        var objective3 = new SituationVariantObjective(coffeeEnVariant.Id);
        objective3.AddTranslation("en", "Ask for the price or the bill");
        objective3.AddTranslation("pt-BR", "Perguntar o preço ou pedir a conta");

        context.SituationVariantObjectives.AddRange(objective1, objective2, objective3);
        await context.SaveChangesAsync();
    }
}
