﻿// /*
// * Copyright (c) 2016, Alachisoft. All Rights Reserved.
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// * http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alachisoft.NosDB.Common.Server.Engine.Impl
{
    public class DropSessionCommand:DatabaseOperation, IDropSessionOperation
    {
        private Alachisoft.NosDB.Common.Protobuf.DropSessionCommand.Builder _dropSessionCommand;
        private string _sessionId;

        public DropSessionCommand()
        {
            _dropSessionCommand = new Alachisoft.NosDB.Common.Protobuf.DropSessionCommand.Builder();
            base.Message = this;
        }

        public DropSessionCommand(Alachisoft.NosDB.Common.Protobuf.Command command)
            : base(command.ToBuilder())
        {
            _dropSessionCommand = command.DropSessionCommand.ToBuilder();
            _sessionId = _dropSessionCommand.SessionId;
            base.Message = this;
      
        }

        internal override void BuildInternal()
        {
            _dropSessionCommand.SessionId = _sessionId;

            base._command.SetDropSessionCommand(_dropSessionCommand);
            base._command.SetType(Alachisoft.NosDB.Common.Protobuf.Command.Types.Type.DROP_SESSION);
        }

        public override IDBResponse CreateResponse()
        {
            DatabaseResponse response = new DatabaseResponse();
            response.RequestId = base.RequestId;
            return response;
        }

        public override IDBOperation Clone()
        {
            return base.Clone();
        }

        public string SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }
    }
}
