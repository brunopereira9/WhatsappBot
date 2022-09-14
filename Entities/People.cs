using WhatsappBot.Dto;

namespace WhatsappBot.Entities
{
    public class People
    {
        public People(string name, string phone, bool isPrivate=false, bool isVerified=false)
        {
            Name = name;
            Phone = phone;
            IsDeleted = false;
            IsVerified = isVerified;
            IsPrivate = isPrivate;
        }
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Phone { get; private set; }
        public string? Birthday { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? Cep { get; private set; }
        public string? City { get; private set; }
        public string? Cpf { get; private set; }
        public string? Gender { get; private set; }
        public string? Uf { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public bool IsPrivate { get; private set; } = false;
        public bool IsVerified { get; private set; } = false;
        public DateTime CreatedAt { get; private set;} = DateTime.Now;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        public DateTime? DeletedAt { get; private set; }
        
        public void SetName(string name){
            Name = name;
            SetUpdatedAt();
        }
        
        public void SetPhone(string phone){
            Phone = phone;
            SetUpdatedAt();
        }
        
        public void SetIsPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
            SetUpdatedAt();
        }
        
        public void SetIsVerified(bool isVerified)
        {
            IsVerified = isVerified;
            SetUpdatedAt();
        }
        
        public void SetBirthday(string birthday){
            Birthday = birthday;
            SetUpdatedAt();
        }
        public void SetNeighborhood(string neighborhood){
            Neighborhood = neighborhood;
            SetUpdatedAt();
        }
        public void SetCep(string cep){
            Cep = cep;
            SetUpdatedAt();
        }
        public void SetCity(string city){
            City = city;
            SetUpdatedAt();
        }
        public void SetCpf(string cpf){
            Cpf = cpf;
            SetUpdatedAt();
        }
        public void SetGender(string gender){
            Gender = gender;
            SetUpdatedAt();
        }
        public void SetUf(string uf){
            Uf = uf;
            SetUpdatedAt();
        }

        private void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
        public void SoftRemove(){
            IsDeleted = true;
            DeletedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}