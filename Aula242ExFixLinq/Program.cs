using Aula242ExFixLinq.Entities;
using System.Globalization;

namespace Aula242ExFixLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inicando com a solicitação do caminho do arquivo a ser lido
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            //Recebendo o valor do salário fornecido pelo usuário
            Console.Write("Enter salary: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Instanciando uma lista do tipo Employee 
            List<Employee> list = new List<Employee>();

            //Bloco using para leitura do arquivo do caminho informado com StreamReader sr recebendo o File.OpenText(path) para abrir o arquivo em texto(string) do caminho 
            using (StreamReader sr = File.OpenText(path))
            {
                //Estrutura de repetição para ler todas as linhas na qual opera enquanto NÃO chega no final do aquivo de leitura
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(','); //vetor de string recebendo a linha do arquivo e separando em campos através da virgula
                    string name = fields[0]; //string name recebe a posição 0 do vetor
                    string email = fields[1]; //string email recebe a posição 1 do vetor
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture); //double salary recebe a posição 2 do vetor convertida para double

                    list.Add(new Employee(name, email, salary)); //adicionando um novo objeto Employee recebendo o name, email e salary
                }

                Console.WriteLine("Email of people whose salary is more than 2000.00:");
                //Linq na qual uma variável genérica emailPeople recebe a lista com .Where(onde) p => p.Salary seja menor que o preço
                //Então ordena por .OrderBy p tal que p.email e por fim pega apenas o email da lista
                var emailPeople = list.Where(p => p.Salary > price).OrderBy(p => p.Email).Select(p => p.Email);
                //Foreach - para cara string email em emailPeople, imprime na tela o email ordenado de forma crescente
                foreach (string email in emailPeople)
                {
                    Console.WriteLine(email);
                }

                //Linq na qual uma variável genérica sum recebe a lista onde (.Where) a primeira letra seja 'M' (p tal que p.Name[0] seja igual a 'M'
                //E por fim faz a soma (.Sum) do salário (p tal que p.Salary) e converte para string com duas casas decimais
                var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary).ToString("F2", CultureInfo.InvariantCulture);
                Console.Write("Sum of salary of people whose name starts eith 'M': " + sum);
            }


        }
    }
}
