/*
   Copyright © 2020 Sidemash Cloud Services

   Licensed under the Apache  License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless  required  by  applicable  law  or  agreed to in writing,
   software  distributed  under  the  License  is distributed on an
   "AS IS"  BASIS, WITHOUT  WARRANTIES  OR CONDITIONS OF  ANY KIND,
   either  express  or  implied.  See the License for the  specific
   language governing permissions and limitations under the License.
*/


using LanguageExt;
using Newtonsoft.Json.Linq;
using System;
using static LanguageExt.Prelude;

namespace Sidemash.Sdk
{
    public class InstanceStatus : IEquatable<InstanceStatus> {
        private string Value { get; }
    
        internal InstanceStatus(string value) {
            Value = value;
        }
    
        public class InitializingT : InstanceStatus
        {
            public InitializingT() : base("Initializing") { }
        }
    
        public class RunningT : InstanceStatus
        {
            public RunningT() : base("Running") { }
        }
    
        public class RestartingT : InstanceStatus
        {
            public RestartingT() : base("Restarting") { }
        }
    
        public class UpdatingT : InstanceStatus
        {
            public UpdatingT() : base("Updating") { }
        }
    
        public class MaintainingT : InstanceStatus
        {
            public MaintainingT() : base("Maintaining") { }
        }
    
        public class PartiallyAvailableT : InstanceStatus
        {
            public PartiallyAvailableT() : base("PartiallyAvailable") { }
        }
    
        public class NotAvailableT : InstanceStatus
        {
            public NotAvailableT() : base("NotAvailable") { }
        }
    
        public class TerminatingT : InstanceStatus
        {
            public TerminatingT() : base("Terminating") { }
        }
    
        public class TerminatedT : InstanceStatus
        {
            public TerminatedT() : base("Terminated") { }
        }
    
        public static readonly InitializingT Initializing = new InitializingT();
        public static readonly RunningT Running = new RunningT();
        public static readonly RestartingT Restarting = new RestartingT();
        public static readonly UpdatingT Updating = new UpdatingT();
        public static readonly MaintainingT Maintaining = new MaintainingT();
        public static readonly PartiallyAvailableT PartiallyAvailable = new PartiallyAvailableT();
        public static readonly NotAvailableT NotAvailable = new NotAvailableT();
        public static readonly TerminatingT Terminating = new TerminatingT();
        public static readonly TerminatedT Terminated = new TerminatedT();
    
        public static readonly Set<string> AllPossiblesValues =
            Set("Initializing",
                "Running",
                "Restarting",
                "Updating",
                "Maintaining",
                "PartiallyAvailable",
                "NotAvailable",
                "Terminating",
                "Terminated");
    
        public static Option<InstanceStatus> FromString(string value)
        {
            if(value.Equals(Initializing.Value)) return Some<InstanceStatus>(Initializing);
            if(value.Equals(Running.Value)) return Some<InstanceStatus>(Running);
            if(value.Equals(Restarting.Value)) return Some<InstanceStatus>(Restarting);
            if(value.Equals(Updating.Value)) return Some<InstanceStatus>(Updating);
            if(value.Equals(Maintaining.Value)) return Some<InstanceStatus>(Maintaining);
            if(value.Equals(PartiallyAvailable.Value)) return Some<InstanceStatus>(PartiallyAvailable);
            if(value.Equals(NotAvailable.Value)) return Some<InstanceStatus>(NotAvailable);
            if(value.Equals(Terminating.Value)) return Some<InstanceStatus>(Terminating);
            if(value.Equals(Terminated.Value)) return Some<InstanceStatus>(Terminated);
            return None;
        }
    
        public static bool IsValid(string value)
        {
            return AllPossiblesValues.Contains(value);
        }
    
        public static bool IsNotInitializing(string value)
        {
            return !value.Equals("Initializing");
        }
    
        public static bool IsNotRunning(string value)
        {
            return !value.Equals("Running");
        }
    
        public static bool IsNotRestarting(string value)
        {
            return !value.Equals("Restarting");
        }
    
        public static bool IsNotUpdating(string value)
        {
            return !value.Equals("Updating");
        }
    
        public static bool IsNotMaintaining(string value)
        {
            return !value.Equals("Maintaining");
        }
    
        public static bool IsNotPartiallyAvailable(string value)
        {
            return !value.Equals("PartiallyAvailable");
        }
    
        public static bool IsNotNotAvailable(string value)
        {
            return !value.Equals("NotAvailable");
        }
    
        public static bool IsNotTerminating(string value)
        {
            return !value.Equals("Terminating");
        }
    
        public static bool IsNotTerminated(string value)
        {
            return !value.Equals("Terminated");
        }
    
        public static void IfNotInitializing(string value, Action<InstanceStatus> fn)
        {
             if(IsNotInitializing(value)) fn(Initializing);
        }
    
        public static void IfNotRunning(string value, Action<InstanceStatus> fn)
        {
             if(IsNotRunning(value)) fn(Running);
        }
    
        public static void IfNotRestarting(string value, Action<InstanceStatus> fn)
        {
             if(IsNotRestarting(value)) fn(Restarting);
        }
    
        public static void IfNotUpdating(string value, Action<InstanceStatus> fn)
        {
             if(IsNotUpdating(value)) fn(Updating);
        }
    
        public static void IfNotMaintaining(string value, Action<InstanceStatus> fn)
        {
             if(IsNotMaintaining(value)) fn(Maintaining);
        }
    
        public static void IfNotPartiallyAvailable(string value, Action<InstanceStatus> fn)
        {
             if(IsNotPartiallyAvailable(value)) fn(PartiallyAvailable);
        }
    
        public static void IfNotNotAvailable(string value, Action<InstanceStatus> fn)
        {
             if(IsNotNotAvailable(value)) fn(NotAvailable);
        }
    
        public static void IfNotTerminating(string value, Action<InstanceStatus> fn)
        {
             if(IsNotTerminating(value)) fn(Terminating);
        }
    
        public static void IfNotTerminated(string value, Action<InstanceStatus> fn)
        {
             if(IsNotTerminated(value)) fn(Terminated);
        }
    
        public static bool IsInitializing(string value)
        {
            return value.Equals("Initializing");
        }
    
        public static bool IsRunning(string value)
        {
            return value.Equals("Running");
        }
    
        public static bool IsRestarting(string value)
        {
            return value.Equals("Restarting");
        }
    
        public static bool IsUpdating(string value)
        {
            return value.Equals("Updating");
        }
    
        public static bool IsMaintaining(string value)
        {
            return value.Equals("Maintaining");
        }
    
        public static bool IsPartiallyAvailable(string value)
        {
            return value.Equals("PartiallyAvailable");
        }
    
        public static bool IsNotAvailable(string value)
        {
            return value.Equals("NotAvailable");
        }
    
        public static bool IsTerminating(string value)
        {
            return value.Equals("Terminating");
        }
    
        public static bool IsTerminated(string value)
        {
            return value.Equals("Terminated");
        }
    
        public static Option<InitializingT> AsInitializingOption(string value)
        {
             return IsInitializing(value) ? Some(Initializing) : None;
        }
    
        public static Option<RunningT> AsRunningOption(string value)
        {
             return IsRunning(value) ? Some(Running) : None;
        }
    
        public static Option<RestartingT> AsRestartingOption(string value)
        {
             return IsRestarting(value) ? Some(Restarting) : None;
        }
    
        public static Option<UpdatingT> AsUpdatingOption(string value)
        {
             return IsUpdating(value) ? Some(Updating) : None;
        }
    
        public static Option<MaintainingT> AsMaintainingOption(string value)
        {
             return IsMaintaining(value) ? Some(Maintaining) : None;
        }
    
        public static Option<PartiallyAvailableT> AsPartiallyAvailableOption(string value)
        {
             return IsPartiallyAvailable(value) ? Some(PartiallyAvailable) : None;
        }
    
        public static Option<NotAvailableT> AsNotAvailableOption(string value)
        {
             return IsNotAvailable(value) ? Some(NotAvailable) : None;
        }
    
        public static Option<TerminatingT> AsTerminatingOption(string value)
        {
             return IsTerminating(value) ? Some(Terminating) : None;
        }
    
        public static Option<TerminatedT> AsTerminatedOption(string value)
        {
             return IsTerminated(value) ? Some(Terminated) : None;
        }
    
        public static void IfInitializing(string value, Action<InitializingT> fn)
        {
             if(IsInitializing(value)) fn(Initializing);
        }
    
        public static void IfRunning(string value, Action<RunningT> fn)
        {
             if(IsRunning(value)) fn(Running);
        }
    
        public static void IfRestarting(string value, Action<RestartingT> fn)
        {
             if(IsRestarting(value)) fn(Restarting);
        }
    
        public static void IfUpdating(string value, Action<UpdatingT> fn)
        {
             if(IsUpdating(value)) fn(Updating);
        }
    
        public static void IfMaintaining(string value, Action<MaintainingT> fn)
        {
             if(IsMaintaining(value)) fn(Maintaining);
        }
    
        public static void IfPartiallyAvailable(string value, Action<PartiallyAvailableT> fn)
        {
             if(IsPartiallyAvailable(value)) fn(PartiallyAvailable);
        }
    
        public static void IfNotAvailable(string value, Action<NotAvailableT> fn)
        {
             if(IsNotAvailable(value)) fn(NotAvailable);
        }
    
        public static void IfTerminating(string value, Action<TerminatingT> fn)
        {
             if(IsTerminating(value)) fn(Terminating);
        }
    
        public static void IfTerminated(string value, Action<TerminatedT> fn)
        {
             if(IsTerminated(value)) fn(Terminated);
        }
    
        public bool IsValid()
        {
            return IsValid(this.Value);
        }
    
        public bool IsNotInitializing()
        {
            return IsNotInitializing(this.Value);
        }
    
        public bool IsNotRunning()
        {
            return IsNotRunning(this.Value);
        }
    
        public bool IsNotRestarting()
        {
            return IsNotRestarting(this.Value);
        }
    
        public bool IsNotUpdating()
        {
            return IsNotUpdating(this.Value);
        }
    
        public bool IsNotMaintaining()
        {
            return IsNotMaintaining(this.Value);
        }
    
        public bool IsNotPartiallyAvailable()
        {
            return IsNotPartiallyAvailable(this.Value);
        }
    
        public bool IsNotNotAvailable()
        {
            return IsNotNotAvailable(this.Value);
        }
    
        public bool IsNotTerminating()
        {
            return IsNotTerminating(this.Value);
        }
    
        public bool IsNotTerminated()
        {
            return IsNotTerminated(this.Value);
        }
    
        public void IfNotInitializing(Action<InstanceStatus> fn)
        {
            IfNotInitializing(this.Value, fn);
        }
    
        public void IfNotRunning(Action<InstanceStatus> fn)
        {
            IfNotRunning(this.Value, fn);
        }
    
        public void IfNotRestarting(Action<InstanceStatus> fn)
        {
            IfNotRestarting(this.Value, fn);
        }
    
        public void IfNotUpdating(Action<InstanceStatus> fn)
        {
            IfNotUpdating(this.Value, fn);
        }
    
        public void IfNotMaintaining(Action<InstanceStatus> fn)
        {
            IfNotMaintaining(this.Value, fn);
        }
    
        public void IfNotPartiallyAvailable(Action<InstanceStatus> fn)
        {
            IfNotPartiallyAvailable(this.Value, fn);
        }
    
        public void IfNotNotAvailable(Action<InstanceStatus> fn)
        {
            IfNotNotAvailable(this.Value, fn);
        }
    
        public void IfNotTerminating(Action<InstanceStatus> fn)
        {
            IfNotTerminating(this.Value, fn);
        }
    
        public void IfNotTerminated(Action<InstanceStatus> fn)
        {
            IfNotTerminated(this.Value, fn);
        }
    
        public bool IsInitializing()
        {
            return IsInitializing(this.Value);
        }
    
        public bool IsRunning()
        {
            return IsRunning(this.Value);
        }
    
        public bool IsRestarting()
        {
            return IsRestarting(this.Value);
        }
    
        public bool IsUpdating()
        {
            return IsUpdating(this.Value);
        }
    
        public bool IsMaintaining()
        {
            return IsMaintaining(this.Value);
        }
    
        public bool IsPartiallyAvailable()
        {
            return IsPartiallyAvailable(this.Value);
        }
    
        public bool IsNotAvailable()
        {
            return IsNotAvailable(this.Value);
        }
    
        public bool IsTerminating()
        {
            return IsTerminating(this.Value);
        }
    
        public bool IsTerminated()
        {
            return IsTerminated(this.Value);
        }
    
        public Option<InitializingT> AsInitializingOption()
        {
             return AsInitializingOption(this.Value);
        }
    
        public Option<RunningT> AsRunningOption()
        {
             return AsRunningOption(this.Value);
        }
    
        public Option<RestartingT> AsRestartingOption()
        {
             return AsRestartingOption(this.Value);
        }
    
        public Option<UpdatingT> AsUpdatingOption()
        {
             return AsUpdatingOption(this.Value);
        }
    
        public Option<MaintainingT> AsMaintainingOption()
        {
             return AsMaintainingOption(this.Value);
        }
    
        public Option<PartiallyAvailableT> AsPartiallyAvailableOption()
        {
             return AsPartiallyAvailableOption(this.Value);
        }
    
        public Option<NotAvailableT> AsNotAvailableOption()
        {
             return AsNotAvailableOption(this.Value);
        }
    
        public Option<TerminatingT> AsTerminatingOption()
        {
             return AsTerminatingOption(this.Value);
        }
    
        public Option<TerminatedT> AsTerminatedOption()
        {
             return AsTerminatedOption(this.Value);
        }
    
        public void IfInitializing(Action<InitializingT> fn)
        {
            IfInitializing(this.Value, fn);
        }
    
        public void IfRunning(Action<RunningT> fn)
        {
            IfRunning(this.Value, fn);
        }
    
        public void IfRestarting(Action<RestartingT> fn)
        {
            IfRestarting(this.Value, fn);
        }
    
        public void IfUpdating(Action<UpdatingT> fn)
        {
            IfUpdating(this.Value, fn);
        }
    
        public void IfMaintaining(Action<MaintainingT> fn)
        {
            IfMaintaining(this.Value, fn);
        }
    
        public void IfPartiallyAvailable(Action<PartiallyAvailableT> fn)
        {
            IfPartiallyAvailable(this.Value, fn);
        }
    
        public void IfNotAvailable(Action<NotAvailableT> fn)
        {
            IfNotAvailable(this.Value, fn);
        }
    
        public void IfTerminating(Action<TerminatingT> fn)
        {
            IfTerminating(this.Value, fn);
        }
    
        public void IfTerminated(Action<TerminatedT> fn)
        {
            IfTerminated(this.Value, fn);
        }
    
        public static InstanceStatus FromJson(JToken json)
        {
            return new InstanceStatus(json.ToString());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            return new JValue(Value);
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as InstanceStatus);
        }
    
        public bool Equals(InstanceStatus other)
        {
            return other != null &&
                   Value == other.Value;
        }
    
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
        public override string ToString() => 
            Value;
    }
}