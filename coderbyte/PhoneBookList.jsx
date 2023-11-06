import React, { useState } from "react";
import { createRoot } from "react-dom/client";

const style = {
    table: {
        borderCollapse: "collapse"
    },
    tableCell: {
        border: "1px solid gray",
        margin: 0,
        padding: "5px 10px",
        width: "max-content",
        minWidth: "150px"
    },
    form: {
        container: {
            padding: "20px",
            border: "1px solid #F0F8FF",
            borderRadius: "15px",
            width: "max-content",
            marginBottom: "40px"
        },
        inputs: {
            marginBottom: "5px"
        },
        submitBtn: {
            marginTop: "10px",
            padding: "10px 15px",
            border: "none",
            backgroundColor: "lightseagreen",
            fontSize: "14px",
            borderRadius: "5px"
        }
    }
};

function PhoneBookForm({ addContact }) {
    const [formContact, setFormContact] = useState({
        firstName: "Coder",
        lastName: "Byte",
        phone: "8885559999"
    });
    // Update state on input change
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormContact((prev) => ({
            ...prev,
            [name]: value
        }));
    };

    // On form submit, call the addContact function
    const handleSubmit = (e) => {
        e.preventDefault();
        addContact(formContact);
    };
    return (
        <form onSubmit={(e) => handleSubmit(e)} style={style.form.container}>
            <label>First name:</label>
            <br />
            <input
                style={style.form.inputs}
                className="userFirstname"
                name="firstName"
                type="text"
                value={formContact.firstName}
                onChange={handleInputChange}
            />
            <br />
            <label>Last name:</label>
            <br />
            <input
                style={style.form.inputs}
                className="userLastname"
                name="lastName"
                type="text"
                value={formContact.lastName}
                onChange={handleInputChange}
            />
            <br />
            <label>Phone:</label>
            <br />
            <input
                style={style.form.inputs}
                className="userPhone"
                name="phone"
                type="text"
                value={formContact.phone}
                onChange={handleInputChange}
            />
            <br />
            <input
                style={style.form.submitBtn}
                className="submitButton"
                type="submit"
                value="Add User"
            />
        </form>
    );
}

function InformationTable({ list }) {
    return (
        <table style={style.table} className="informationTable">
            <thead>
                <tr>
                    <th style={style.tableCell}>First name</th>
                    <th style={style.tableCell}>Last name</th>
                    <th style={style.tableCell}>Phone</th>
                </tr>
            </thead>
            <tbody>
                {list.map((contact, index) => (
                    <tr key={index}>
                        <td style={style.tableCell}>{contact.firstName}</td>
                        <td style={style.tableCell}>{contact.lastName}</td>
                        <td style={style.tableCell}>{contact.phone}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

function Application() {
    const [contactList, setContactList] = useState([]);

    const addContact = (newContact) => {
        setContactList((prevList) => {
            const updatedList = [...prevList, newContact].sort((a, b) =>
                a.lastName.localeCompare(b.lastName)
            );
            return updatedList;
        });
    };

    return (
        <section>
            <PhoneBookForm addContact={addContact} />
            <InformationTable list={contactList} />
        </section>
    );
}

const container = document.getElementById("root");
const root = createRoot(container);
root.render(<Application />);
