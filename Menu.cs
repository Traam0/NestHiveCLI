using NestHive.ToolKit.Elements;
using NestHive.ToolKit.Interfaces;

namespace NestHive.ToolKit
{
    public class Menu: INavigatable

    {
        private readonly AppHeader? _header;
        private readonly string _prompt;
        private readonly MenuOption[] _options;
        public int Cursor { get; private set; }

        public Menu(string propmt, MenuOption[] options, AppHeader? header) { 
            this._header = header;
            this._prompt = propmt;
            this._options = options;
            this.Cursor = 0;
        }

        void INavigatable.Build()
        {
            this._header?.Display();
            for(int i=0; i<this._options.Length; i++)
            {
                if(this.Cursor == i)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"|--> {this._options[i].Label}");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"| {this._options[i].Label}");
            }
        }

        public void Show()
        {
            Console.Clear();
            (this as  INavigatable).Build();

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    this.Cursor = ++this.Cursor % this._options.Length ;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    this.Cursor = --this.Cursor < 0 ? this._options.Length -1  : this.Cursor;
                    break;

                case ConsoleKey.Enter:
                    this._options[Cursor].Execute();
                    return;
            }

            this.Show();
        }
    }


    public class MenuBuilder: IBuilder<Menu>
    {
        private AppHeader? _header;
        private string _prompt;
        private List<MenuOption> _options;

        public MenuBuilder() {
            _header = null;
            _prompt = string.Empty;
            _options = new List<MenuOption>();
        }

        public MenuBuilder SetHeader(AppHeader header)
        {
            if(this._header != null)
                this._header = header;


            return this;
        }

        public MenuBuilder SetPrompt(string prompt)
        {
            if(string.IsNullOrEmpty(this._prompt) || string.IsNullOrWhiteSpace(this._prompt)) 
                this._prompt = prompt;
            return this;
        }

        public MenuBuilder AddOption(MenuOption option)
        {
            if((from o in this._options where o.Label == option.Label select 0).Count() == 0) 
                this._options.Add(option);

            return this;
        }

        public Menu Build()
        {
            try
            {
                if (string.IsNullOrEmpty(this._prompt) || string.IsNullOrWhiteSpace(this._prompt) || _options.Count == 0)
                {
                    throw new ArgumentException();
                }

                return new Menu(this._prompt, this._options.ToArray(), this._header);
            }catch(Exception ex)
            {
                //!todo  add Logger
                throw;
            }
        }
    }

}