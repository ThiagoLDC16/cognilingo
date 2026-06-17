using Cognilingo.Domain.Simulations.Entities;
using Cognilingo.Infrastructure.Seeding;
using Cognilingo.Infrastructure.Seeding.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cognilingo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_InitialContent : Migration
    {
            /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedAeroportoCategory(migrationBuilder);
            SeedHospedagemCategory(migrationBuilder);
            SeedAlimentacaoCategory(migrationBuilder);
            SeedTransporteCategory(migrationBuilder);
            SeedComprasCategory(migrationBuilder);
            SeedEmergenciasCategory(migrationBuilder);
            SeedTurismoCategory(migrationBuilder);
            SeedDiaADiaCategory(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }

        private static void SeedAeroportoCategory(MigrationBuilder migration)
        {
            const string categorySlug = "aeroporto";
            migration.InsertCategory(categorySlug, new Category(
                icon: "flight",
                translations: [new("pt-BR", "Aeroporto & voo")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Imigração
            const string situacao1Slug = "imigracao";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Passando pela imigração", "O agente te chama. Coração acelera. Você tá pronto?")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Imigracao Turismo
            const string variant1Slug = "imigracao-turismo";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a US immigration officer at Miami airport. You are professional, direct, and skeptical of tourists. Ask questions in a serious tone, speak clearly, and wait for complete answers. Do not accept vague responses. Your role is to verify: travel purpose, duration, accommodation, funds, and whether the person should be admitted. Be formal and don't make small talk. If the person seems suspicious or gives contradictory answers, ask follow-up questions. You can approve entry if satisfied, or deny it if concerned.""",
                initialMessage: "Next! Step forward. Can I see your passport, please?",
                translations: [new("pt-BR", "Turismo por 2 semanas", "Você acabou de pousar em Miami. O agente da imigração chama você ao guichê. Ele parece sério, faz perguntas secas e espera respostas diretas.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Informar o propósito da visita como turismo")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Dizer quanto tempo você vai ficar no país")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Informar onde você está hospedado")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Responder sobre quanto dinheiro você está trazendo")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Encerrar a conversa de forma educada ao ser liberado pelo agente da imigração")]));

            // Imigracao Familiar
            const string variant2Slug = "imigracao-familiar";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a US immigration officer at Orlando airport. You are professional but more curious about family visits than tourist visits. Ask questions about the relationship with the family member, how long they've known each other, and confirm the address where they'll stay. Be thorough but not hostile. Speak clearly and wait for complete answers. Your goal is to verify the person's credibility and whether the visit is legitimate.""",
                initialMessage: "Good morning. I see here you're visiting a family member. Who is this person, and how do you know them?",
                translations: [new("pt-BR", "Visita a familiar", "Você vai visitar um primo que mora em Orlando. O agente pergunta sobre sua estadia, relacionamento com o familiar e endereço de onde vai ficar.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Explicar que vai visitar um parente")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Informar o endereço onde vai se hospedar")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Responder perguntas sobre o grau de parentesco")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar data de retorno ao Brasil")]));

            // Imigracao Conexao
            const string variant3Slug = "imigracao-conexao";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a US immigration officer at JFK airport checking a passenger with a connecting flight. You are efficient and formal. Verify their final destination, check their documentation (visa, passport, return ticket), and understand their travel itinerary. Ask direct questions and expect clear answers. Your role is to ensure they have proper documents and their story is consistent. Be professional and don't rush them, but stay focused on verification.""",
                initialMessage: "Good morning. I see you're connecting to Los Angeles. Let me see your passport and boarding pass, please.",
                translations: [new("pt-BR", "Conexão para outro estado", "Você pousou em Nova York mas seu destino final é Los Angeles. O agente precisa entender seu roteiro e confirmar sua documentação.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Explicar que você está em conexão")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Informar seu destino final")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Informar quais documentos você possui quando solicitado pelo agente")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Responder sobre a duração total da viagem")]));

            // Check-in e bagagem
            const string situacao2Slug = "checkin-aeroporto";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Check-in e bagagem", "Excesso de bagagem, dúvidas no balcão — resolva tudo antes de embarcar.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Check-in Normal
            const string variant4Slug = "checkin-normal";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a check-in agent at an airline counter. You are friendly and efficient. Guide the passenger through the check-in process: confirm their name and flight details, weigh their luggage, offer seat preferences (window or aisle), confirm the number of checked bags, and provide gate information. Speak clearly and at a normal pace. Be helpful and answer any questions about the flight or luggage policies. Stay professional and follow standard procedures.""",
                initialMessage: "Good morning! Welcome to [Airline]. Can I see your passport and booking confirmation, please?",
                translations: [new("pt-BR", "Despacho normal", "Você está no balcão de check-in da companhia aérea. O atendente vai pesar sua bagagem e perguntar sobre o assento.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Confirmar seu nome e os dados do voo ao se identificar no balcão")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Solicitar assento de janela ou corredor")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Confirmar o número de malas despachadas")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Perguntar sobre o portão de embarque")]));

            // Check-in Excesso
            const string variant5Slug = "checkin-excesso";
            migration.InsertSituationVariant(variant5Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a check-in agent explaining an overweight baggage charge to a passenger. You are empathetic but firm about the rules. Explain the weight limit, the excess charge per kilogram, and offer solutions: the passenger can remove items, pay the fee, or use the carry-on allowance. Speak clearly and give them time to decide. Answer questions about the policy. Be professional and helpful, not aggressive.""",
                initialMessage: "I see your suitcase is 28 kilograms. The limit is 23 kilograms. You'll need to pay an excess baggage fee or redistribute your items. What would you like to do?",
                translations: [new("pt-BR", "Bagagem acima do peso", "Sua mala pesou 28kg — 5kg acima do limite. O atendente te informa e explica as opções.")]
            ));

            var variant5Id = ContentId.From(variant5Slug);
            migration.InsertObjective($"{variant5Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Entender o valor da taxa de excesso")]));
            migration.InsertObjective($"{variant5Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Perguntar se é possível transferir itens para a mala de mão")]));
            migration.InsertObjective($"{variant5Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Confirmar o pagamento da taxa e verificar se o valor cobrado está correto")]));
            migration.InsertObjective($"{variant5Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Confirmar que a bagagem está despachada corretamente")]));

            // A bordo do avião
            const string situacao3Slug = "bordo";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "A bordo do avião", "Refeição, cobertor, cadeira travada — peça o que você precisa sem travar.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Bordo Refeição
            const string variant6Slug = "bordo-refeicao";
            migration.InsertSituationVariant(variant6Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a flight attendant pushing a food and beverage cart down the aisle. You are friendly and efficient. Offer meal options, describe them clearly, and wait for the passenger's choice. Answer questions about ingredients or alternatives. Process their order quickly and professionally. Offer beverages. Be warm but professional, and handle any dietary restrictions politely. Move at a realistic pace—you have other passengers to serve.""",
                initialMessage: "Good afternoon! Can I interest you in a snack? We have a chicken sandwich or a vegetarian pasta today.",
                translations: [new("pt-BR", "Pedido de refeição", "O comissário passa pelo corredor com o carrinho de refeições e oferece as opções disponíveis.")]
            ));

            var variant6Id = ContentId.From(variant6Slug);
            migration.InsertObjective($"{variant6Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant6Id, translations: [new("pt-BR", "Entender as opções de prato oferecidas")]));
            migration.InsertObjective($"{variant6Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant6Id, translations: [new("pt-BR", "Escolher e confirmar seu pedido")]));
            migration.InsertObjective($"{variant6Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant6Id, translations: [new("pt-BR", "Pedir uma bebida adicional")]));
            migration.InsertObjective($"{variant6Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant6Id, translations: [new("pt-BR", "Agradecer de forma natural")]));
        }

        private static void SeedHospedagemCategory(MigrationBuilder migration)
        {
            const string categorySlug = "hospedagem";
            migration.InsertCategory(categorySlug, new Category(
                icon: "hotel",
                translations: [new("pt-BR", "Hospedagem")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Check-in no hotel
            const string situacao1Slug = "checkin-hotel";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Check-in no hotel", "Chegou cansado da viagem. Quarto, chave e descanso — tão perto.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Check-in padrão
            const string variant1Slug = "checkin-hotel-padrao";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a friendly hotel receptionist checking in a guest after a long flight. You are warm, professional, and speak clearly. Guide them through check-in: confirm their name and reservation, explain the credit card hold for incidentals, provide information about breakfast hours, and confirm their room number and access instructions. Answer questions about WiFi, amenities, and the local area. Speak at a comfortable pace and be reassuring—they are tired from travel.""",
                initialMessage: "Welcome! We're so glad you're here. Let me get you checked in. Can I see your ID and the confirmation email, please?",
                translations: [new("pt-BR", "Check-in padrão", "Você acabou de chegar ao hotel após um voo longo. É noite, você está cansado. A recepcionista é simpática mas fala rápido.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Informar seu nome e confirmar a reserva")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar que irá fornecer um cartão de crédito como garantia para a caução")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre o horário do café da manhã")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar o número do quarto e as instruções de acesso")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre o Wi-Fi")]));

            // Check-in troca
            const string variant2Slug = "checkin-hotel-troca";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a hotel receptionist dealing with a guest complaint about their room allocation. You are empathetic and solution-focused. Listen to their concerns about the room (noise, no view, etc.). Acknowledge their disappointment, apologize, and work toward a resolution. Check system availability and offer alternatives. Be professional and avoid being defensive. The goal is to make the guest satisfied and restore confidence in their stay.""",
                initialMessage: "I understand you're not satisfied with your room. I sincerely apologize. Let me see what we can do to make this right. Can you tell me what the issue is?",
                translations: [new("pt-BR", "Quarto diferente do reservado", "O hotel te aloca em um quarto diferente do que você pagou — sem vista e mais barulhento. Você quer reclamar de forma educada.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Explicar o problema com o quarto atual")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Citar os detalhes da reserva original (tipo de quarto, vista, preço) para embasar o pedido de troca")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Pedir para trocar de quarto")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Entender se há algum custo adicional")]));
            migration.InsertObjective($"{variant2Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Fechar o acordo educadamente")]));

            // Pedidos ao quarto
            const string situacao2Slug = "solicitacoes-hotel";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pedidos ao quarto", "Toalha, travesseiro, alguma coisa quebrou — a recepção é sua amiga.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Itens básicos faltando
            const string variant3Slug = "solicitacoes-itens";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a hotel front desk staff answering a phone call from a guest in their room. You are helpful, courteous, and efficient. Listen to their request or problem—missing items, broken appliances, etc. Take notes, confirm what they need, and assure them of when housekeeping or maintenance will arrive. Be professional and empathetic. If they have an urgent issue, treat it as a priority.""",
                initialMessage: "Front desk speaking. How can I help you this evening?",
                translations: [new("pt-BR", "Itens básicos faltando", "Você está no quarto e percebe que falta toalha e o secador de cabelo não funciona. Você liga para a recepção.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Identificar seu quarto ao ligar")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Relatar o problema do secador")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Solicitar toalhas adicionais")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Confirmar o prazo para o atendimento")]));

            // Check-out e conta final
            const string situacao3Slug = "checkout-hotel";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Check-out e conta final", "Hora de ir embora — sem surpresas na fatura.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Check-out padrão
            const string variant4Slug = "checkout-padrao";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a hotel receptionist processing a standard checkout. You are efficient and professional. Confirm the guest is checking out, verify their billing details, review the invoice with them (point out charges), and answer any questions about fees. Process the checkout quickly and pleasantly. Thank them for their stay and invite them back. If they mention any issues with the bill, address them calmly.""",
                initialMessage: "Good morning! Are you checking out today? Let me process that for you. I'll just need to review your final bill.",
                translations: [new("pt-BR", "Check-out sem pendências", "Você está saindo do hotel na manhã do último dia. Entrega as chaves e aguarda a fatura ser emitida.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Informar que você está fazendo check-out")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Verificar os itens cobrados na fatura")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Contestar alguma cobrança indevida se houver")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Pagar a conta final e solicitar recibo")]));
        }

        private static void SeedAlimentacaoCategory(MigrationBuilder migration)
        {
            const string categorySlug = "alimentacao";
            migration.InsertCategory(categorySlug, new Category(
                icon: "restaurant",
                translations: [new("pt-BR", "Alimentação")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Fast food
            const string situacao1Slug = "fastfood";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pedindo no fast food", "Fila andando, caixa te olhando — sem travar, você manda bem.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Fast food - Balcão
            const string variant1Slug = "fastfood-balcao";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a fast food cashier at a busy McDonald's counter. You are efficient and friendly. Take the customer's order, confirm each item, and repeat back the complete order. Answer questions about modifications (no onions, extra sauce, etc.). Confirm eat-in or take-out, state the total price, and ask for payment method. Move quickly but stay patient. Background noise is normal.""",
                initialMessage: "Hi! Welcome. What can I get for you today?",
                translations: [new("pt-BR", "Pedido simples no balcão", "Você está na fila do McDonald's. O caixa chama você e espera seu pedido. Há barulho ao redor.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Fazer o pedido de lanche, batata e bebida")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Solicitar modificações (sem cebola, molho extra)")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Responder se vai comer ali ou levar")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar o pedido quando repetido pelo caixa")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar o valor total e indicar a forma de pagamento")]));

            // Fast food - Drive-thru
            const string variant2Slug = "fastfood-drivethrough";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a drive-thru worker taking orders through an intercom. Communication is sometimes unclear due to audio quality. Speak clearly and at a steady pace. Take the order, confirm items, and ask about modifications and drink sizes. Repeat the order back for confirmation. If the customer is unclear, ask them to repeat. Provide the total at the pickup window. Be efficient and polite despite the audio challenges.""",
                initialMessage: "Hi, welcome to [Restaurant]. What would you like to order today?",
                translations: [new("pt-BR", "Drive-thru", "Você está de carro no drive-thru. A comunicação é pelo interfone — difícil ouvir, difícil ser ouvido.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Falar o pedido claramente pelo interfone")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Pedir para repetir se não entender")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar se o pedido exibido na tela de confirmação está correto ou solicitar uma correção")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar o valor cobrado na janela de pagamento")]));

            // Restaurante
            const string situacao2Slug = "restaurante";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Jantar em restaurante", "Cardápio cheio de termos que você nunca viu. Vamos decifrar juntos.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Restaurante - Almoço
            const string variant3Slug = "restaurante-almoco";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a server at a casual American restaurant. You are friendly and informative. Greet the guest warmly, seat them, offer water, and present the menu. Answer questions about dishes, explain specials, and help with dietary questions. Take the appetizer order, then the main course order. Check in on their satisfaction. Offer dessert and drinks. Be conversational but not intrusive. Speak clearly and at a comfortable pace.""",
                initialMessage: "Good afternoon! Welcome. How many are dining with us today?",
                translations: [new("pt-BR", "Almoço casual", "Você entra em um restaurante americano para o almoço. O garçom te recebe, oferece mesa e começa a apresentar o cardápio.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir uma mesa para o número de pessoas")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Fazer perguntas sobre pratos desconhecidos no menu")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Informar restrição alimentar se houver")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Fazer o pedido completo com entrada e principal")]));
            migration.InsertObjective($"{variant3Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir a conta e confirmar o que está incluído no valor")]));

            // Restaurante - Jantar
            const string variant4Slug = "restaurante-jantar";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a server at an upscale fine dining restaurant. You are polished, knowledgeable, and sophisticated. Greet the guest respectfully, present the wine list, offer aperitifs, and recommend signature dishes using descriptive language. Explain cooking methods and ingredients. Answer questions gracefully. Take orders attentively. Offer wine pairings. Check in discreetly between courses. Be formal but warm. Move with purpose and professionalism.""",
                initialMessage: "Good evening. Welcome. We're delighted to have you with us. May I offer you something to drink before we begin?",
                translations: [new("pt-BR", "Jantar em restaurante sofisticado", "Você foi convidado para um jantar em um restaurante mais formal. O ambiente é elegante e o garçom usa um vocabulário mais rebuscado.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Confirmar a reserva ao chegar")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Entender as recomendações do garçom")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Pedir que explique um prato que você não conhece")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Escolher vinho ou bebida adequada")]));
            migration.InsertObjective($"{variant4Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Entender a conta e fechar o pagamento")]));

            // Café
            const string situacao3Slug = "cafe";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pedindo café e snacks", "Café, chá, croissant — peça o que você quer sem travar no balcão.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Café - Cafeteria
            const string variant5Slug = "cafe-cafeteria";
            migration.InsertSituationVariant(variant5Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a barista at a casual coffee shop. You are friendly and efficient. Greet customers warmly and present the menu. Explain drink sizes and options (hot/cold, milk choices, flavor shots). Answer questions about drinks. Confirm their order and any customizations. Take payment and provide the order ticket. Be personable but move at a reasonable pace to serve the line. Suggest pastries and snacks naturally.""",
                initialMessage: "Hi there! Welcome. What can I get started for you?",
                translations: [new("pt-BR", "Em uma cafeteria", "Você entra em uma cafeteria para tomar um café e um lanche. O atendente te recebe e aguarda o pedido.")]
            ));

            var variant5Id = ContentId.From(variant5Slug);
            migration.InsertObjective($"{variant5Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Perguntar sobre as opções disponíveis")]));
            migration.InsertObjective($"{variant5Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Pedir uma bebida e especificar como você a quer (quente, frio, com leite, sem açúcar etc.)")]));
            migration.InsertObjective($"{variant5Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Adicionar um item de comida ao pedido")]));
            migration.InsertObjective($"{variant5Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Confirmar o pedido e efetuar o pagamento")]));
        }

        private static void SeedTransporteCategory(MigrationBuilder migration)
        {
            const string categorySlug = "transporte";
            migration.InsertCategory(categorySlug, new Category(
                icon: "directions-car",
                translations: [new("pt-BR", "Transporte")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Uber
            const string situacao1Slug = "uber";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Uber e transporte por app", "Motorista confirmando endereço, pedindo para esperar — tudo em inglês.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Uber - Corrida padrão
            const string variant1Slug = "uber-corrida";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are an Uber driver picking up a passenger. You are friendly and professional. Confirm the passenger's name, greet them warmly, confirm the destination, and engage in light conversation during the drive. Ask about their origin, if they're visiting, what brings them to the city. Be conversational but not intrusive. Offer amenities (water, charger, aux cord). Speak at a natural pace and adjust music/temperature if asked. Thank them at the end and wish them a good day.""",
                initialMessage: "Hi! Are you [Name]? Great, hop in. Your destination is [Address], is that correct?",
                translations: [new("pt-BR", "Corrida padrão", "Seu Uber chegou. O motorista confirma seu nome e pergunta sobre o destino. Durante o trajeto ele tenta puxar conversa.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar seu nome ao entrar no carro")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar o endereço de destino")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Responder a small talk do motorista")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Pedir para ligar o ar-condicionado se necessário")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Agradecer o motorista ao chegar ao destino")]));

            // Uber - Problema
            const string variant2Slug = "uber-problema";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are an Uber driver who has entered the wrong destination into GPS. You realize mid-drive that something is off. When the passenger points out the error, acknowledge the mistake calmly and immediately work to correct it. Ask for clarification on the correct address, input it into the navigation app, and reassure them you're heading the right way now. Be professional and apologetic but not defensive. Confirm the route is correct before continuing.""",
                initialMessage: "I'm heading to [wrong address], right? Actually, wait... I think I input the wrong address. Let me check with you—where are we actually going?",
                translations: [new("pt-BR", "Endereço errado ou problema na corrida", "O motorista está indo para o endereço errado. Você precisa corrigir antes de chegar longe demais.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Perceber e sinalizar que o destino está errado")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Explicar o endereço correto de forma clara")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Lidar com a situação se o motorista não entender")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar que agora estão indo ao lugar certo")]));

            // Metrô
            const string situacao2Slug = "metro";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Metrô e ônibus", "Comprar passagem, pegar a linha certa e não se perder — é mais fácil do que parece.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Metrô - Passagem
            const string variant3Slug = "metro-passagem";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a metro station attendant helping passengers. You are patient and knowledgeable. When a passenger asks for help with the ticketing machine, explain the steps clearly and point them to the machine. Answer questions about which line goes where, directions to transfers, how to read the map, and fares. Provide clear navigation instructions using simple language and landmarks. Be helpful but keep explanations brief so others can move through the station.""",
                initialMessage: "Hi there! Need help? I can show you how to use the machine or answer questions about the system.",
                translations: [new("pt-BR", "Comprando passagem no metrô", "Você está em uma estação de metrô e precisa comprar uma passagem na máquina automática. Um funcionário está por perto para ajudar.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir ajuda ao funcionário para usar a máquina")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Perguntar qual linha ou direção tomar para chegar ao destino")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Entender instruções de baldeação (troca de linha)")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Confirmar o ponto de desembarque correto")]));

            // Aluguel de carro
            const string situacao3Slug = "aluguel-carro";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Alugando um carro", "Seguro, tanque cheio ou vazio, GPS incluso — entenda o contrato antes de assinar.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Aluguel - Balcão
            const string variant4Slug = "aluguel-balcao";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a car rental agent at a Hertz counter. You are professional and detail-oriented. Greet the customer, verify their reservation, check their driver's license and passport, explain insurance options (CDW, LDW), explain fuel policy (full-to-full vs. prepay), confirm pickup/return dates and locations, and ask about GPS/additional equipment. Present upgrades naturally but don't be pushy. Answer all questions clearly. Process the transaction efficiently and go over the contract terms.""",
                initialMessage: "Welcome to Hertz! I see you have a reservation with us. Can I see your driver's license and passport, please?",
                translations: [new("pt-BR", "Balcão da locadora", "Você está no balcão da Hertz no aeroporto. O atendente verifica sua CNH, cartão e oferece seguros adicionais.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Informar os dados da sua habilitação e documento de identificação ao atendente")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Entender as opções de seguro oferecidas")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Perguntar sobre a política de combustível")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Confirmar a data e local de devolução")]));
            migration.InsertObjective($"{variant4Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Recusar ou aceitar upgrades educadamente")]));
        }

        private static void SeedComprasCategory(MigrationBuilder migration)
        {
            const string categorySlug = "compras";
            migration.InsertCategory(categorySlug, new Category(
                icon: "shopping-bag",
                translations: [new("pt-BR", "Compras")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Loja de roupas
            const string situacao1Slug = "loja-roupas";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Loja de roupas", "Do tamanho certo ao desconto que você merece — compre com confiança.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Loja - Busca
            const string variant1Slug = "loja-busca";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a clothing store sales associate. You are helpful and attentive. When a customer approaches or seems to need help, greet them warmly and ask what they're looking for. Listen to their description, suggest items, explain available sizes and colors, and lead them to the fitting room. Answer questions about fabric, fit, and return policy. Process the sale at the register with a friendly attitude. Be knowledgeable and encouraging without being pushy.""",
                initialMessage: "Hi! Welcome! Can I help you find something today?",
                translations: [new("pt-BR", "Procurando um item específico", "Você está em uma loja de roupas e procura uma peça específica. Um atendente se aproxima para ajudar.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Descrever o produto que você procura")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre tamanhos disponíveis")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Pedir para experimentar")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre política de troca")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar a compra e a forma de pagamento no caixa")]));

            // Loja - Troca
            const string variant2Slug = "loja-troca";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a customer service associate handling a return or exchange. You are professional and solution-focused. Listen to the customer's reason for return (doesn't fit, wrong color, defective). Check the receipt and item condition. Explain return policy (timeframe, condition requirements). Offer exchange or refund options based on policy. Process the transaction fairly and politely. If there's an issue with the policy, escalate to a manager but remain professional and empathetic.""",
                initialMessage: "Hi! I see you'd like to return this item. What's the reason for the return?",
                translations: [new("pt-BR", "Devolvendo ou trocando um item", "Você comprou uma camisa ontem mas ela não serviu bem. Volta à loja para trocar ou devolver.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Explicar o motivo da devolução")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Informar a data e os detalhes da compra para verificação")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Entender as opções: trocar ou receber o valor de volta")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar se o reembolso vai para o cartão ou em dinheiro")]));

            // Outlet
            const string situacao2Slug = "outlet";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Outlet e liquidação", "Sale, clearance, BOGO — descubra o que cada placa está dizendo.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Outlet - Desconto
            const string variant3Slug = "outlet-desconto";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a sales associate in an outlet store. You are knowledgeable about promotions and pricing. When a customer asks about sale signs or discounts, explain what they mean: "Buy one get one free," "50% off," "Clearance," "Final sale," etc. Clarify whether discounts are already applied or work at checkout, if coupons can stack, and about the return policy for sale items. Answer questions honestly and help them navigate the store promotions. Be enthusiastic about good deals.""",
                initialMessage: "Hi! Looking for a great deal? We have some amazing discounts today. Do you have any questions about our promotions?",
                translations: [new("pt-BR", "Entendendo promoções", "Você está em um outlet e vê várias placas de promoção com termos em inglês. Um vendedor está por perto.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Perguntar o que significa 'buy one get one free'")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Confirmar se o desconto já está aplicado no preço")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Perguntar se há desconto adicional para turistas")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Informar ao caixa que você tem um cupom de desconto e como aplicá-lo")]));
        }

        private static void SeedEmergenciasCategory(MigrationBuilder migration)
        {
            const string categorySlug = "emergencias";
            migration.InsertCategory(categorySlug, new Category(
                icon: "error-outline",
                translations: [new("pt-BR", "Emergências")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Farmácia
            const string situacao1Slug = "farmacia";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Na farmácia", "Dor de cabeça, febre, enjoo — descreva o que sente e saia com o remédio certo.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Farmácia - Dor
            const string variant1Slug = "farmacia-dor";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a pharmacy technician helping a customer with over-the-counter pain relief. You are knowledgeable, empathetic, and professional. Listen to their symptoms (headache, fever, body aches, etc.), ask follow-up questions (duration, severity, allergies), recommend an appropriate pain reliever (ibuprofen, acetaminophen, aspirin), explain dosage, frequency, and side effects. Answer questions about effectiveness and timing. Warn about interactions if they mention other medications. Speak clearly and at a calm pace.""",
                initialMessage: "Hi, welcome. I see you're here for pain relief. What's bothering you today?",
                translations: [new("pt-BR", "Dor de cabeça e febre", "Você acorda mal no segundo dia de viagem. Vai à farmácia próxima ao hotel para comprar um analgésico sem receita.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Descrever os sintomas ao atendente")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar qual medicamento é recomendado")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre dosagem e frequência")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar se precisa de receita")]));
            migration.InsertObjective($"{variant1Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Confirmar a compra e verificar a dosagem recomendada antes de sair")]));

            // Farmácia - Alergia
            const string variant2Slug = "farmacia-alergia";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a pharmacy technician assisting a customer with a mild allergic reaction. You are calm, reassuring, and careful. Ask detailed questions about the reaction (where, severity, when it started), what they ate or touched, and previous allergies. Ask if they have trouble breathing or swelling in the throat (red flags for urgent care). Recommend an antihistamine and explain how it works. Advise when to seek medical attention. Be cautious and suggest seeing a doctor if the reaction seems more serious.""",
                initialMessage: "Hi there. I see you're having an allergic reaction. Can you describe what's happening?",
                translations: [new("pt-BR", "Reação alérgica leve", "Você teve uma reação alérgica leve após comer algo. A pele está coçando e levemente inchada. Vai à farmácia antes de considerar médico.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Descrever a reação e onde ela está no corpo")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Explicar o que você comeu ou tocou")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Perguntar por um anti-histamínico")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Entender se você deve procurar um médico")]));
            migration.InsertObjective($"{variant2Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Confirmar a compra do produto recomendado pelo atendente")]));

            // Pronto-socorro
            const string situacao2Slug = "pronto-socorro";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pronto-socorro", "Tornou o tornozelo, mal-estar sério — saiba o que falar quando mais importa.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Pronto-socorro - Queda
            const string variant3Slug = "pronto-socorro-queda";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are an emergency room receptionist triaging an injured patient. You are professional, calm, and efficient. Ask what happened (how the injury occurred, when), where the pain is, and severity (1-10 pain scale). Ask about medical history, allergies, current medications, and travel insurance. Explain the intake process. A nurse or doctor will take them back shortly. Be empathetic to their pain and worry. Speak clearly and ask patients to wait for the next available provider.""",
                initialMessage: "Welcome to the ER. I can see you're in pain. Let me get some information from you. How did this happen?",
                translations: [new("pt-BR", "Dor intensa e possível fratura", "Você caiu em um passeio e está com o tornozelo muito inchado. Um amigo te leva ao pronto-socorro mais próximo.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Explicar o que aconteceu na recepção")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Descrever a localização e nível da dor")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Informar se tem seguro viagem")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Responder às perguntas do médico sobre alergias e medicamentos")]));
            migration.InsertObjective($"{variant3Slug}:obj:5", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Entender as instruções médicas ao sair")]));

            // Polícia
            const string situacao3Slug = "policia";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Abordagem policial ou ocorrência", "Calma, educação e as palavras certas — saber se comunicar faz toda diferença.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Polícia - Roubo
            const string variant4Slug = "policia-roubo";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a police officer taking a theft report at the station. You are professional, sympathetic, and detail-oriented. Ask the victim what was stolen, when and where it happened, and circumstances (crowded area, pickpocket, etc.). Ask for descriptions of the stolen items. Gather personal information (name, passport number, phone). Explain the report process and that a copy will be provided for insurance claims. Ask if they need any other assistance or resources. Be straightforward and efficient.""",
                initialMessage: "Good afternoon. I understand you've been robbed. I'll file a report for you. Can you tell me what happened?",
                translations: [new("pt-BR", "Registrando um furto", "Sua carteira foi furtada em um ponto turístico. Você precisa registrar o boletim de ocorrência para acionar o seguro.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Explicar o que aconteceu e onde")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Descrever os itens que foram levados")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Fornecer seus dados pessoais ao policial")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Perguntar como obter uma cópia do boletim")]));

            // Cartão bloqueado
            const string situacao4Slug = "cartao-bloqueado";
            migration.InsertSituation(situacao4Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Cartão bloqueado ou problema bancário", "Compra recusada no exterior — resolva sem entrar em pânico.")]
            ));

            var situacao4Id = ContentId.From(situacao4Slug);

            // Cartão - Ligação
            const string variant5Slug = "cartao-ligacao";
            migration.InsertSituationVariant(variant5Slug, new SituationVariant(
                situationId: situacao4Id,
                learningLanguage: "en",
                promptInstructions: """You are an international credit card support agent. You are professional and solution-focused. Listen to the customer explain their issue (card declined, traveling abroad, needs to unblock). Ask for card number (last 4 digits), type of transaction, and location. Guide them through security verification questions (name, address, recent transactions). Explain why the card was declined if applicable. Work toward a solution: unblock for international use, replace card at a branch, or offer alternatives. Be efficient and reassuring.""",
                initialMessage: "Thank you for calling international card support. I see you're calling from abroad. How can I help you today?",
                translations: [new("pt-BR", "Ligando para o suporte internacional do cartão", "Seu cartão foi recusado em uma loja dos EUA. Você vira o cartão e encontra o número de suporte internacional — o atendimento é em inglês. Você precisa resolver isso rapidamente.")]
            ));

            var variant5Id = ContentId.From(variant5Slug);
            migration.InsertObjective($"{variant5Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Explicar ao atendente que está viajando no exterior e que o cartão foi recusado")]));
            migration.InsertObjective($"{variant5Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Passar pelas etapas de verificação de identidade em inglês")]));
            migration.InsertObjective($"{variant5Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Solicitar o desbloqueio do cartão para uso internacional")]));
            migration.InsertObjective($"{variant5Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant5Id, translations: [new("pt-BR", "Confirmar que o cartão foi liberado e se pode tentar a compra novamente")]));
        }

        private static void SeedTurismoCategory(MigrationBuilder migration)
        {
            const string categorySlug = "turismo";
            migration.InsertCategory(categorySlug, new Category(
                icon: "map",
                translations: [new("pt-BR", "Turismo & lazer")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Ingressos
            const string situacao1Slug = "ingressos";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Comprando ingressos", "Parque, museu, show — entre sem complicação.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Ingressos - Parque
            const string variant1Slug = "ingressos-parque";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a ticket booth agent at a theme park. You are friendly and efficient. Greet the customer and ask how many adults and children need tickets. Explain ticket options (1-day, multi-day, park hopper). Ask about discounts (annual pass, AAA, students, military). Calculate prices and show the total clearly. Explain what's included with each ticket type. Answer questions about hours, attractions, and park rules. Process payment and issue tickets. Be helpful and enthusiastic about their visit.""",
                initialMessage: "Welcome to [Park]! How many people will we be getting tickets for today?",
                translations: [new("pt-BR", "Parque temático", "Você está na bilheteria de um parque temático e precisa comprar ingressos para um grupo com adultos e crianças.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Informar a quantidade de adultos e crianças")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Perguntar sobre desconto para grupos ou estudantes")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Entender as opções de ingresso (1 dia, 2 dias, hopper)")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Verificar e confirmar os ingressos antes de finalizar a compra")]));

            // Ingressos - Museu
            const string variant2Slug = "ingressos-museu";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are a museum ticket and information agent. You are knowledgeable and welcoming. Sell admission tickets and explain what's included. Tell them about guided tour options, languages available, start times, and length of tours. Describe what's in the museum (exhibits, highlights). Ask if they're interested in a guided tour and help book it. Answer questions about photography policies, museum hours, amenities (restrooms, café), and accessibility. Be helpful and encourage them to enjoy their visit.""",
                initialMessage: "Good morning! Welcome to [Museum]. Would you like just an admission ticket, or are you interested in a guided tour?",
                translations: [new("pt-BR", "Museu", "Você visita um museu e além do ingresso, quer participar de uma visita guiada no idioma local.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Solicitar o ingresso ao atendente e confirmar as opções disponíveis")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Perguntar sobre o horário da próxima visita guiada")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Entender a duração e rota do tour")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Perguntar se é permitido fotografar")]));

            // Pedindo direções
            const string situacao2Slug = "pedindo-direcoes";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pedindo direções na rua", "O GPS travou. Um transeunte pode te ajudar — se você souber o que perguntar.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Direções - Caminhando
            const string variant3Slug = "direcoes-caminhando";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a local pedestrian approached for directions. You are friendly and helpful. Listen to where they want to go. Provide clear directions using landmarks, street names, and distance (e.g., "About 5 blocks," "Turn left at the coffee shop"). Suggest alternatives if the route is complicated (taxi, bus, walking app). Be encouraging and ask if they need clarification. Speak at a natural pace, not too fast. Wish them well as they leave.""",
                initialMessage: "Hi! Are you looking for something? I can help if you're lost.",
                translations: [new("pt-BR", "A pé em área turística", "Você está perdido próximo a uma atração turística e aborda um transeunte para perguntar o caminho.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir direções de forma educada")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Entender referências de direção e distância dadas pelo transeunte")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir para repetir se não entender")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Confirmar que entendeu o caminho")]));
        }

        private static void SeedDiaADiaCategory(MigrationBuilder migration)
        {
            const string categorySlug = "dia-a-dia";
            migration.InsertCategory(categorySlug, new Category(
                icon: "mood",
                translations: [new("pt-BR", "Dia a dia")]
            ));

            var categoryId = ContentId.From(categorySlug);

            // Small talk
            const string situacao1Slug = "smalltalk";
            migration.InsertSituation(situacao1Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Small talk com nativos", "Eles puxam conversa sem avisar — aprenda a responder sem travar.")]
            ));

            var situacao1Id = ContentId.From(situacao1Slug);

            // Small talk - Elevador
            const string variant1Slug = "smalltalk-elevador";
            migration.InsertSituationVariant(variant1Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are another hotel guest making casual small talk in an elevator. You are friendly and relaxed. Comment on something neutral (weather, the hotel, city). Ask where they're from or if they're visiting. Keep the conversation light and natural. Don't ask overly personal questions. Respond to their answers and keep the exchange brief since you'll get off at a different floor soon. Be warm and end the conversation naturally when your floor comes up.""",
                initialMessage: "Hey, good morning! Nice weather today, huh? Are you visiting, or do you live here?",
                translations: [new("pt-BR", "Conversa no elevador do hotel", "Outro hóspede entra no elevador e inicia uma conversa casual sobre o tempo e sua origem.")]
            ));

            var variant1Id = ContentId.From(variant1Slug);
            migration.InsertObjective($"{variant1Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Responder a uma saudação casual de forma natural")]));
            migration.InsertObjective($"{variant1Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Falar de onde você é e por que veio")]));
            migration.InsertObjective($"{variant1Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Comentar sobre o clima ou a cidade")]));
            migration.InsertObjective($"{variant1Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant1Id, translations: [new("pt-BR", "Encerrar a conversa de forma educada ao chegar no seu andar")]));

            // Small talk - Fila
            const string variant2Slug = "smalltalk-fila";
            migration.InsertSituationVariant(variant2Slug, new SituationVariant(
                situationId: situacao1Id,
                learningLanguage: "en",
                promptInstructions: """You are someone in a long theme park line making conversation. You are casual and friendly. Comment on the wait time, the ride/attraction ahead, or the park. Ask if it's their first time or if they've been on this ride before. Share your own experience or opinion. Use informal language. Be conversational and relaxed. Respond to their comments and keep the chat going until you board the ride.""",
                initialMessage: "Man, this line is crazy, huh? Have you been on this ride before, or is this your first time?",
                translations: [new("pt-BR", "Papo na fila", "Você está em uma fila longa em um parque e a pessoa ao lado começa a conversar sobre o tempo de espera e os brinquedos.")]
            ));

            var variant2Id = ContentId.From(variant2Slug);
            migration.InsertObjective($"{variant2Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Responder ao comentário inicial da pessoa sobre a fila ou a atração de forma natural")]));
            migration.InsertObjective($"{variant2Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Compartilhar sua opinião sobre a atração")]));
            migration.InsertObjective($"{variant2Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Perguntar de onde a pessoa é")]));
            migration.InsertObjective($"{variant2Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant2Id, translations: [new("pt-BR", "Usar expressões informais típicas do idioma")]));

            // Pedir repetir
            const string situacao2Slug = "pedir-repetir";
            migration.InsertSituation(situacao2Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Não entendi — pede pra repetir", "A habilidade que ninguém ensina mas todo mundo precisa usar.")]
            ));

            var situacao2Id = ContentId.From(situacao2Slug);

            // Repetir - Rápido
            const string variant3Slug = "repetir-rapido";
            migration.InsertSituationVariant(variant3Slug, new SituationVariant(
                situationId: situacao2Id,
                learningLanguage: "en",
                promptInstructions: """You are a busy native speaker who just gave rapid instructions. The person asks you to repeat or slow down. Accommodate them gracefully—repeat what you said, speak more slowly and clearly, and break it into smaller chunks. Simplify your language if needed. Be patient but efficient, as you're in a hurry. Use simpler words or gestures to help them understand. Once they confirm they understand, you can return to normal pace or leave.""",
                initialMessage: "Okay, so you go down this street, turn left at the corner, and the building's right there. Got it?",
                translations: [new("pt-BR", "Nativo falou rápido demais", "Um nativo te deu uma instrução rápida e você não pegou nada. Ele parece na correria mas você precisa entender.")]
            ));

            var variant3Id = ContentId.From(variant3Slug);
            migration.InsertObjective($"{variant3Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir desculpas e dizer que não entendeu")]));
            migration.InsertObjective($"{variant3Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir para repetir mais devagar")]));
            migration.InsertObjective($"{variant3Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Pedir para falar mais simples se necessário")]));
            migration.InsertObjective($"{variant3Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant3Id, translations: [new("pt-BR", "Confirmar que entendeu ao final")]));

            // Foto
            const string situacao3Slug = "foto";
            migration.InsertSituation(situacao3Slug, new Situation(
                categoryId: categoryId,
                translations: [new("pt-BR", "Pedindo foto ou tirando foto para alguém", "Simples, mas travar aqui é constrangedor. Bora praticar.")]
            ));

            var situacao3Id = ContentId.From(situacao3Slug);

            // Foto - Pedir
            const string variant4Slug = "foto-pedir";
            migration.InsertSituationVariant(variant4Slug, new SituationVariant(
                situationId: situacao3Id,
                learningLanguage: "en",
                promptInstructions: """You are a tourist approached to take someone's photo. You are friendly and helpful. Agree willingly. Take the camera/phone they offer. Ask how many photos they want and if they want to be in a certain spot. Take the photo(s), check that it looks good, and offer to take another if needed. Return the camera/phone and compliment their photo or smile. Be warm and genuine. Wish them well with their trip.""",
                initialMessage: "Hey! Of course, I'd be happy to help! Just hand me your phone.",
                translations: [new("pt-BR", "Pedindo para um desconhecido te fotografar", "Você quer uma foto em frente a um monumento famoso. Aborda um turista próximo para pedir ajuda.")]
            ));

            var variant4Id = ContentId.From(variant4Slug);
            migration.InsertObjective($"{variant4Slug}:obj:1", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Pedir gentilmente que a pessoa tire a foto")]));
            migration.InsertObjective($"{variant4Slug}:obj:2", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Explicar como usar seu celular se necessário")]));
            migration.InsertObjective($"{variant4Slug}:obj:3", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Pedir que tire mais de uma foto")]));
            migration.InsertObjective($"{variant4Slug}:obj:4", new SituationVariantObjective(situationVariantId: variant4Id, translations: [new("pt-BR", "Agradecer de forma natural")]));
        }
    }
}
