/// Copyright (c) 2009, Greg Todd
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without modification,
/// are permitted provided that the following conditions are met:
/// 
/// * Redistributions of source code must retain the above copyright notice,
///   this list of conditions and the following disclaimer.
///   
/// * Redistributions in binary form must reproduce the above copyright notice,
///   this list of conditions and the following disclaimer in the documentation
///   and/or other materials provided with the distribution.
///   
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
/// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
/// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
/// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
/// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
/// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
/// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
/// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
/// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
/// OF THE POSSIBILITY OF SUCH DAMAGE.

using System;

namespace ReflectiveCode.GMinder
{
    public class GventEventArgs : EventArgs
    {
        #region Properties

        public Gvent Gvent { get; private set; }
        public GventChanges Changes { get; private set; }

        #endregion

        public GventEventArgs( Gvent gvent, GventChanges changes )
        {
            Gvent = gvent;
            Changes = changes;
        }
    }

    public class GventAppendixEventArgs : GventEventArgs
    {
        #region Properties

        public GventAppendix Appendix { get; private set; }

        #endregion

        public GventAppendixEventArgs( Gvent gvent, GventAppendix appendix, GventChanges changes )
            : base(gvent, changes)
        {
            Appendix = appendix;
        }
    }

    public enum GventChanges
    {
        None = 0,
        Title = 1,
        Location = 1 << 1,
        Start = 1 << 2,
        Stop = 1 << 3,
        Url = 1 << 4,
        HangoutUrl = 1 << 5,
        Status = 1 << 6,
        Color = 1 << 7,
        Added = 1 << 8,
        Deleted = 1 << 9,
        AddedReminder = 1 << 10,
        DeletedReminder = 1 << 11,
        Description = 1 << 12,
        Organizer = 1 << 13,
        IsRecurrence = 1 << 14,
        Attendees = 1 << 15,
        OptionalAttendees = 1 << 16,
        Resources = 1 << 17,
        LocationResource = 1 << 18,
        AddedAppendix = 1 << 19,
        DeletedAppendix = 1 << 20,
        UpdatedAppendix = 1 << 21
    }
}