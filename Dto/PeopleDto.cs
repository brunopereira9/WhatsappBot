namespace WhatsappBot.Dto
{
    public class PeopleDto
    {
        public string? Name { get; set; }
        public string Phone { get; set; }
        public string? Birthday { get; set; }
        public string? Neighborhood { get; set; }
        public string? Cep { get; set; }
        public string? City { get; set; }
        public string? Cpf { get; set; }
        public string? Gender { get; set; }
        public string? Uf { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}