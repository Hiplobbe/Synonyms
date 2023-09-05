import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { word: "", synonyms: [] };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.getSynonyms = this.getSynonyms.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    static renderSynonymTable(synonyms) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                <th>Synonym</th>
                </tr>
            </thead>
            <tbody>
                {synonyms.map(synonym =>
                <tr key={synonym}>
                    <td>{synonym}</td>
                </tr>
                )}
            </tbody>
            </table>
        );
    }

    render() {
    let contents = FetchData.renderSynonymTable(this.state.synonyms);

    return (
        <div>
            <h1 id="tabelLabel" >Synonyms Lookup</h1>
            <p>Write a word and get its synonyms</p>
            <br />
            <br />
            <label>Word to Lookup</label>
            <br />
            <input name="word" onChange={this.handleInputChange}></input>
            <br />
            <br />
            <button className="btn btn-primary" onClick={this.getSynonyms}>Lookup</button>
            {contents}
        </div>
        );
    }

    async getSynonyms() {
        const response = await fetch('/home/get?word=' + this.state.word);
        const data = await response.json();
        this.setState({ synonyms: data });
    }
}
