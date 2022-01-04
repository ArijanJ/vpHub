using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiParser;
using System.Collections;

namespace vpHub
{
    public class Note
    {
        public int NoteValue;
        public char BaseChar;
        public bool OutOfRange;
        public Note(int noteValue)
        {
            this.NoteValue = noteValue;
            this.BaseChar = MidiConverter.ConvertNote(noteValue);
            this.OutOfRange = (noteValue < 36 || noteValue > 98); // Accepted notes are 21(A1)-108(C7)
        }
        public static bool IsValid(int value)
        {
            return (value >= 21 && value <= 108);
        }
        public bool IsCapital()
        {
            return (MidiConverter.uppercases.Contains(this.BaseChar));
        }
    }

    public class NoteComparer : IEqualityComparer<Note>
    {
        public bool Equals(Note x, Note y)
        {
            return x.NoteValue == y.NoteValue;
        }
        public int GetHashCode(Note x)
        {
            return x.NoteValue.GetHashCode();
        }
    }

    public class Chord
    {
        public List<Note> Notes = new List<Note>();
        public int GetSize()
        {
            return Notes.Count;
        }
        public void AddNote(Note note)
        {
            Notes.Add(note);
        }

        public static void Display(List<Note> notes)
        {
            var TempChord = new Chord();
            TempChord.Notes = notes;
            foreach (var note in TempChord.Notes)
            {
                Console.Write(note.BaseChar);
            }
            Console.Write('\n');
        }

        public void SortChord(bool shiftBegin, bool boldBegin)
        {
            var notes = this.Notes;

            notes = notes.OrderBy(n => n.NoteValue).ToList();

            List<Note> CapitalNotes, OutOfRangeNotes, NormalNotes;
            CapitalNotes = new List<Note>();
            OutOfRangeNotes = new List<Note>();     // i can't set them all in one line cause c# troll
            NormalNotes = new List<Note>();
            var DuplicateNotes = new List<int>(); 

            foreach (var note in notes) //sorted here
            {
                if (DuplicateNotes.Contains(note.NoteValue))
                {
                    continue;
                }
                DuplicateNotes.Add(note.NoteValue);

                // find all low notes
                if (note.OutOfRange == true)
                    OutOfRangeNotes.Add(note);

                // find capitals
                else if (note.IsCapital())
                    CapitalNotes.Add(note);

                else
                    NormalNotes.Add(note);
            }

            this.Notes.Clear();
            //Chord.Display(this.Notes);

            if (shiftBegin == true) // Shifts at Beginning
            {
                if (boldBegin == true) // Bolds at Beginning
                    this.Notes = OutOfRangeNotes.Concat(CapitalNotes).Concat(NormalNotes).ToList(); // Bolds + Capitals + Normals

                else if (boldBegin != true) // Bolds at End
                    this.Notes = CapitalNotes.Concat(NormalNotes).Concat(OutOfRangeNotes).ToList(); // Capitals + Normals + Bolds
            }

            else if (shiftBegin != true) // Shifts at End
            {
                if (boldBegin == true) // Bolds at Beginning
                    this.Notes = OutOfRangeNotes.Concat(NormalNotes).Concat(CapitalNotes).ToList(); // Bolds + Normals + Capitals

                else if (boldBegin != true) // Bolds at End
                    this.Notes = NormalNotes.Concat(CapitalNotes).Concat(OutOfRangeNotes).ToList(); // Normals + Bolds + Capitals
            }

            /*Chord.Display(notes);
            Chord.Display(this.Notes);
            //CapitalNotes, OutOfRangeNotes, NormalNotes, DuplicateNotes;
            Chord.Display(CapitalNotes);
            Chord.Display(OutOfRangeNotes);
            Chord.Display(NormalNotes);*/
        }
    }

    public class Sheet
    {
        public int BPM;
        // Starts at 21, goes all the way up to 108
        public List<Chord> Chords = new();
        public bool[] SpecialPositions = { true, true };
        public void SortSheet()
        {
            foreach(var chord in Chords)
            {
                chord.SortChord(SpecialPositions[0], SpecialPositions[1]);
            }
        }

        public void AddChord(Chord chord)
        {
            Chords.Add(chord);
        }
        public static Sheet Transpose(Sheet sheet, int transposition)
        {
            var newSheet = new Sheet();
            newSheet.Chords = sheet.Chords;

            foreach (Chord chord in newSheet.Chords)
            {
                List<Note> TransposedNotes = new List<Note>();
                foreach (Note note in chord.Notes)
                {
                    var NewNoteValue = note.NoteValue += transposition;
                    if (Note.IsValid(NewNoteValue))
                    {
                        TransposedNotes.Add(new Note(NewNoteValue));
                    }
                }
                chord.Notes = TransposedNotes;
            }

            return newSheet;
        }
    }

    public class MidiConverter
    {
        public const string vpScale = "1234567890qwert1!2@34$5%6^78*9(0qQwWeErtTyYuiIoOpPasSdDfgGhHjJklLzZxcCvVbBnmyuiopasdfghj";
        public const string uppercases = "!@$%^*(QWETYIOPSDGHJLZCVB";
        public static char ConvertNote(int noteValue)
        {
            return vpScale[noteValue - 21]; // 21 is A1, lowest note on the piano
        }
        public static Sheet ConvertMidi(MidiFile midi, List<int> selectedTrackIndexes)
        {
            var sheet = new Sheet();
            var tracks = new List<MidiTrack>();
            foreach(var index in selectedTrackIndexes)
            {
                tracks.Add(midi.Tracks[index]);
            }
            var track = MidiFile.MergeTracks(tracks.ToArray());
            for (var i = 0; i < track.MidiEvents.Count(); i++)
            {
                if (track.MidiEvents[i].MidiEventType == MidiEventType.NoteOn)
                {
                    var MidiEvent = track.MidiEvents[i];
                    var noteValue = MidiEvent.Note;
                    if (!Note.IsValid(noteValue))
                    {
                        continue;
                    }
                    var chord = new Chord();
                    chord.AddNote(new Note(noteValue));
                    // TODO: while previous notes are at same time group into Chord objecs and append into Sheet object
                    // Add all the next notes with the same time into the chord
                    if (!Note.IsValid(track.MidiEvents[i + 1].Note)) continue;
                    while (track.MidiEvents[i].Time == track.MidiEvents[i + 1].Time)
                    {
                        i++;
                        if (!Note.IsValid(track.MidiEvents[i].Note)) continue;
                        chord.AddNote(new Note(track.MidiEvents[i].Note));
                    }
                    sheet.AddChord(chord);
                }
            }
            return sheet;
        }
    }
}