# Core Dictionary Management Tool

The Core Dictionary Management Tool (which I will refer to as CDMT from this point on) is a simple tool for creating, editing, encrypting/decrypting, and converting core dictionaries.

## The User Interface

This application has its own user interface with custom elements.

The form (as you can see) differs from the original Windows Forms. It uses the "neXt Window Management System" library, which allows the form to be handled like a normal form.

Since XWMS has not yet been extensively tested, bugs and other problems may occur. However, I have not encountered any to date, meaning this application also serves as a test application for my management system.

## Compatibility

CDMT is kept as close as possible to a low-level .NET version (.NET 6.0) to ensure compatibility with legacy Windows systems such as Windows 7, 8, and 8.1.


With the creation of MaidNVI, many aspects are updated to .NET 8.0 or higher, which excludes legacy systems.

This is then referred to as the ADK (Avean Development Kit).

## Future Plans

- Inclusion of LTE (Light-Term Encryption) - Currently in a private development and research phase
- AES256 compatibility
- Switching from the ADK to the newer MaidNVI
