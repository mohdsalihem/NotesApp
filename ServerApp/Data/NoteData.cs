using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Entities;

namespace ServerApp.Data
{
    public class NoteData
    {

        public static List<Note> Values = new List<Note>()
        {
            new Note()
            {
                noteId = 1001,
                title = "In Search of Lost Time",
                description = "Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work.",
                createdDate = new DateTime(2022, 05, 10, 10, 15, 00),
                modifiedDate = new DateTime(2022, 05, 10, 10, 15, 00),
                userId = 1
            },
            new Note()
            {
                noteId = 1002,
                title = "One Hundred Years of Solitude",
                description = "One of the 20th century's enduring works, One Hundred Years of Solitude is a widely beloved and acclaimed novel known throughout the world, and the ultimate achievement in a Nobel Prize–winning",
                createdDate = new DateTime(2022, 05, 10, 10, 15, 00),
                modifiedDate = new DateTime(2022, 05, 10, 10, 15, 00),
                userId = 1
            },
            new Note()
            {
                noteId = 1003,
                title = "Hamlet",
                description = "The Tragedy of Hamlet, Prince of Denmark, or more simply Hamlet, is a tragedy by William Shakespeare, believed to have been written between 1599 and 1601.",
                createdDate = new DateTime(2022, 05, 10, 10, 15, 00),
                modifiedDate = new DateTime(2022, 05, 10, 10, 15, 00),
                userId = 1
            },
            new Note()
            {
                noteId = 1004,
                title = "Test Note",
                description = "Test Note Description",
                createdDate = new DateTime(2022, 05, 10, 10, 15, 00),
                modifiedDate = new DateTime(2022, 05, 10, 10, 15, 00),
                userId = 1
            }
        };
    }
}