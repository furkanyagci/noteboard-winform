﻿using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class NoteController
    {
        NoteDAL _noteDAL;
        public NoteController()
        {
            _noteDAL = new NoteDAL();
        }

        public bool Add(Note note)
        {
            note.IsActive = true;
            note.CreatedDate = DateTime.Now;
            return _noteDAL.Add(note) > 0;
        }

        public bool Update(Note note)
        {
            note.ModifiedDate = DateTime.Now;
            return _noteDAL.Update(note) > 0;
        }

        public bool Delete(Note note)
        {
            note.IsActive = false;
            note.ModifiedDate = DateTime.Now;
            return Update(note);
        }

        public Note getById(int noteID)
        {
            return _noteDAL.GetByID(noteID);
        }

        public List<Note> GetNotesByUser(int userID)
        {
            return _noteDAL.GetAll().Where(a => a.UserID == userID && a.IsActive).ToList();
        }


    }
}