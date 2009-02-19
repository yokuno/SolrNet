﻿#region license
// Copyright (c) 2007-2009 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace SolrNet {
    public abstract class AbstractSolrQuery : ISolrQuery {
        public abstract string Query { get; }
        public ISolrQuery Not() {
            return new SolrNotQuery(this);
        }

        public static AbstractSolrQuery operator & (AbstractSolrQuery a, AbstractSolrQuery b) {
            return new SolrMultipleCriteriaQuery(new[] {a, b}, "AND");
        }

        public static AbstractSolrQuery operator | (AbstractSolrQuery a, AbstractSolrQuery b) {
            return new SolrMultipleCriteriaQuery(new[] { a, b }, "OR");
        }

        public static AbstractSolrQuery operator + (AbstractSolrQuery a, AbstractSolrQuery b) {
            return new SolrMultipleCriteriaQuery(new[] {a, b});
        }

        public static bool operator false (AbstractSolrQuery a) {
            return false;
        }

        public static bool operator true (AbstractSolrQuery a) {
            return false;
        }

        public static ISolrQuery operator ! (AbstractSolrQuery a) {
            return a.Not();
        }
    }
}