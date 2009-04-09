#region License, Terms and Author(s)
//
// Gurtle - IBugTraqProvider for Google Code
// Copyright (c) 2008 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// This library is free software; you can redistribute it and/or modify it 
// under the terms of the New BSD License, a copy of which should have 
// been delivered along with this distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
#endregion

namespace Gurtle
{
    #region Imports

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal static class GoogleCodeProject
    {
        public static readonly Uri HostingUrl = new Uri("http://code.google.com/hosting/");

        public static Uri ProjectUrlFromName(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!IsValidProjectName(name)) throw new ArgumentException(null, "name");
            return new Uri("http://code.google.com/p/" + name + "/");
        }

        public static Uri SimpleProjectUrlFromName(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!IsValidProjectName(name)) throw new ArgumentException(null, "name");
            return new Uri("http://" + name + ".googlecode.com/");
        }

        public static bool IsValidProjectName(string name)
        {
            if (name == null) 
                throw new ArgumentNullException("name");
            
            //
            // From http://code.google.com/hosting/createProject:
            //
            //   "...project's name must consist of a lowercase letter, 
            //    followed by lowercase letters, digits, and dashes, 
            //    with no spaces."
            //

            return name.Length > 0 && Regex.IsMatch(name, @"^[a-z][a-z0-9-]*$");
        }
    }
}