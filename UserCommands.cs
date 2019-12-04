using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;
using System;

namespace RikuBot
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
        public async Task sayd(CommandContext ctx, string Message, string DeletedMessage)
        {
            Message = ctx.Message.Content.Remove(0, 5);

            Console.WriteLine("Message not deleted");

            await ctx.Channel.DeleteMessageAsync(ctx.Message);

            Console.WriteLine("Message deleted");

            await ctx.Channel.SendMessageAsync(Message)
                .ConfigureAwait(false);
        }
    }
}
