using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;

namespace OlafBot
{
    class UserCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("say")]
        public async Task say(CommandContext ctx, string Message)
        {
            Message = ctx.Message.Content.Remove(0, 5);

            await ctx.Channel.SendMessageAsync(Message)
                .ConfigureAwait(false);
        }

        [Command("sayd")]
        public async Task sayd(CommandContext ctx, string Message)
        {
            Message = ctx.Message.Content.Remove(0, 5);

            await ctx.Message.DeleteAsync();

            await ctx.Channel.SendMessageAsync(Message)
                .ConfigureAwait(false);
        }

        [Command("scramble")]
        public async Task scramble(CommandContext ctx)
        {
            string[] Names = { "Kyle", "Kito", "Utsu", "Gon" };

            Random r = new Random();

            int index = r.Next(Names.Length);

            var interact = ctx.Client.GetInteractivity();

            string word = Names[index];

            string random = new string(word.ToCharArray().OrderBy(s => (r.Next(2) % 2) == 0).ToArray());

            await ctx.Channel.SendMessageAsync(random)
                .ConfigureAwait(false);

            var correctWord = await interact.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Content == word);

            await ctx.Channel.SendMessageAsync(correctWord.Result.Content + " is Right!");
        }
    }
}
